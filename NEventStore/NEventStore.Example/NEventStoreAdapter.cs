using NEventStore.Persistence.Sql.SqlDialects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NEventStore.Example
{  
    public static class NEventStoreAdapter
    {
        private static IStoreEvents _store;
        static NEventStoreAdapter()
        {
            _store = WireupEventStore();
        }

        private static IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
                         .UsingSqlPersistence("EventStore") // Connection string is in app.config
                         .WithDialect(new MsSqlDialect())
                         .UsingJsonSerialization()
                         .Compress()
                         .Build();
        }

        public static EventStream GetEventStream(string id)
        {
            using(var stream  = _store.OpenStream(id, 0, int.MaxValue))
                return new EventStream { LatestRevision = stream.StreamRevision, Events = stream.CommittedEvents.Select(e => e.Body) };
        }

        public static MaterializedView GetLatestSnapshot(string id)
        {
            return _store.Advanced.GetSnapshot(id, int.MaxValue).Payload as MaterializedView;
        }

        public static void TakeSnapshot(int revision, MaterializedView view)
        {
            _store.Advanced.AddSnapshot(new Snapshot(view.Id.ToString(), revision, view));
        }
        
        public static void AppendToStream<T>(string id, T e, Dictionary<string,object> metadata = null)
        {
            if (string.IsNullOrWhiteSpace(id) || e == null) return;

            using (IEventStream stream = _store.OpenStream(id, int.MinValue, int.MaxValue))
            {
                stream.Add(new EventMessage { Body = e, Headers = metadata ?? new Dictionary<string, object>() });
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}
