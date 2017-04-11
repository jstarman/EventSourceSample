namespace NEventStore.Example
{
    using NEventStore;
    using NEventStore.Persistence.Sql.SqlDialects;
    using Newtonsoft.Json;
    using System;

    internal static class MainProgram
    {
        //private static readonly Guid StreamId = Guid.NewGuid(); // aggregate identifier
        private static readonly int Id = 123; // aggregate identifier

        private static IStoreEvents store;

        private static void Main()
        {
            //Append
            NEventStoreAdapter.AppendToStream(Id.ToString(), new CreatedEvent { Id = Id, CreatedDate = DateTime.Now, Name = "A name" });
            NEventStoreAdapter.AppendToStream(Id.ToString(), new AnotherEvent { AnotherDate = DateTime.Now });
            NEventStoreAdapter.AppendToStream(Id.ToString(), new ThirdEvent { CompletedDate = DateTime.Now });

            //Read Events and Snapshot
            var agg = new AnAggregate(NEventStoreAdapter.GetEventStream(Id.ToString()));
            agg.Save();
            Console.WriteLine(JsonConvert.SerializeObject(agg.View));

            //Read Snapshot
            var agg1 = new AnAggregate(NEventStoreAdapter.GetLatestSnapshot(Id.ToString()));
            Console.WriteLine(JsonConvert.SerializeObject(agg1.View));


            Console.WriteLine(Resources.PressAnyKey);
            Console.ReadKey();
        }

        private static IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
                         .UsingSqlPersistence("EventStore") // Connection string is in app.config
                         .WithDialect(new MsSqlDialect())
                         .UsingJsonSerialization()
                         .Compress()
                         .HookIntoPipelineUsing(new[] { new AuthorizationPipelineHook() })
                         .Build();
        }

        private static void OpenOrCreateStream()
        {
            // we can call CreateStream(StreamId) if we know there isn't going to be any data.
            // or we can call OpenStream(StreamId, 0, int.MaxValue) to read all commits,
            // if no commits exist then it creates a new stream for us.
            using (IEventStream stream = store.OpenStream(Id.ToString(), 0, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Initial event."};
                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        private static void AppendToStream()
        {
            using (IEventStream stream = store.OpenStream(Id.ToString(), int.MinValue, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Second event."};

                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        private static void TakeSnapshot()
        {
            var memento = new AggregateMemento {Value = "snapshot"};
            store.Advanced.AddSnapshot(new Snapshot(Id.ToString(), 2, memento));
        }

        private static void LoadFromSnapshotForwardAndAppend()
        {
            ISnapshot latestSnapshot = store.Advanced.GetSnapshot(Id.ToString(), int.MaxValue);

            using (IEventStream stream = store.OpenStream(latestSnapshot, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Third event (first one after a snapshot)."};

                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}