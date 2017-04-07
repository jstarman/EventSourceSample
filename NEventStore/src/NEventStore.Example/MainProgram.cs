namespace NEventStore.Example
{
    using System;
    using System.Transactions;
    using NEventStore;
    using NEventStore.Dispatcher;
    using NEventStore.Persistence.Sql.SqlDialects;

    internal static class MainProgram
    {
        private static readonly Guid StreamId = Guid.NewGuid(); // aggregate identifier

        private static IStoreEvents store;

        private static void Main()
        {
            using (var scope = new TransactionScope())
            using (store = WireupEventStore())
            {
                OpenOrCreateStream();
                AppendToStream();
                TakeSnapshot();
                LoadFromSnapshotForwardAndAppend();
                scope.Complete();
            }

            Console.WriteLine(Resources.PressAnyKey);
            Console.ReadKey();
        }

        private static IStoreEvents WireupEventStore()
        {
            return Wireup.Init()
                         .UsingSqlPersistence("EventStore") // Connection string is in app.config
                         .WithDialect(new MsSqlDialect())
                         .InitializeStorageEngine()
                         .TrackPerformanceInstance("example")
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
            using (IEventStream stream = store.OpenStream(StreamId, 0, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Initial event."};
                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        private static void AppendToStream()
        {
            using (IEventStream stream = store.OpenStream(StreamId, int.MinValue, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Second event."};

                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }

        private static void TakeSnapshot()
        {
            var memento = new AggregateMemento {Value = "snapshot"};
            store.Advanced.AddSnapshot(new Snapshot(StreamId.ToString(), 2, memento));
        }

        private static void LoadFromSnapshotForwardAndAppend()
        {
            ISnapshot latestSnapshot = store.Advanced.GetSnapshot(StreamId.ToString(), int.MaxValue);

            using (IEventStream stream = store.OpenStream(latestSnapshot, int.MaxValue))
            {
                var @event = new SomeDomainEvent {Value = "Third event (first one after a snapshot)."};

                stream.Add(new EventMessage {Body = @event});
                stream.CommitChanges(Guid.NewGuid());
            }
        }
    }
}