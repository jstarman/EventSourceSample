using System;
using System.Collections.Generic;

namespace NEventStore.Example
{

    public class CreatedEvent
    {
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AnotherEvent
    {
        public DateTime AnotherDate { get; set; }
    }

    public class ThirdEvent
    {
        public DateTime CompletedDate { get; set; }
        public string Description { get; set; }
    }

    public class MaterializedView
    {
        public DateTime CreatedDate { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AnotherDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Description { get; set; }
    }

    public class EventStream
    {
        public int LatestRevision { get; set; }
        public IEnumerable<object> Events { get; set; }
    }

    public class AnAggregate
    {
        private EventStream _events;

        public MaterializedView View { get; private set; }

        public AnAggregate(EventStream events)
        {
            _events = events;
            View = new MaterializedView();
            foreach (var aEvent in _events.Events)
            {              
                if (aEvent is CreatedEvent)
                {
                    When((CreatedEvent)aEvent);
                    continue;
                }

                if (aEvent is AnotherEvent)
                {
                    When((AnotherEvent)aEvent);
                    continue;
                }

                if (aEvent is ThirdEvent)
                {
                    When((ThirdEvent)aEvent);
                    continue;
                }
            }
        }

        public AnAggregate(MaterializedView e)
        {
            View = e;
        }

        public void Save()
        {
            NEventStoreAdapter.TakeSnapshot(_events.LatestRevision, View);
        }

        private void When(CreatedEvent e)
        {
            View.CreatedDate = e.CreatedDate;
            View.Id = e.Id;
            View.Name = e.Name;
        }

        private void When(AnotherEvent e)
        {
            View.AnotherDate = e.AnotherDate;
        }

        private void When(ThirdEvent e)
        {
            View.CompletedDate = e.CompletedDate;
            View.Description = e.Description;
        }
    }
}
