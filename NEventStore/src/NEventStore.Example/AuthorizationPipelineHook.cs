namespace NEventStore.Example
{
    using System;
    using NEventStore;

    public class AuthorizationPipelineHook : IPipelineHook
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public ICommit Select(ICommit committed)
        {
            return committed;
        }

        public bool PreCommit(CommitAttempt attempt)
        {
            return true;
        }

        public void PostCommit(ICommit committed)
        {

            // This is where we'd hook into our messaging infrastructure, such as NServiceBus,
            // MassTransit, WCF, or some other communications infrastructure.
            // This can be a class as well--just implement IDispatchCommits.
            try
            {
                foreach (EventMessage @event in committed.Events)
                    Console.WriteLine(Resources.MessagesDispatched + ((SomeDomainEvent)@event.Body).Value);
            }
            catch (Exception)
            {
                Console.WriteLine(Resources.UnableToDispatch);
            }
        }

        public void OnPurge(string bucketId)
        {
            throw new NotImplementedException();
        }

        public void OnDeleteStream(string bucketId, string streamId)
        {
            throw new NotImplementedException();
        }
    }
}