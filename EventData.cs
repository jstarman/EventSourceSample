using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceSample
{
    public class ImportantEvent
    {
        public Guid Id { get; set; }
        public string EventType { get; set; }
        public int EventId { get; set; }
        public string EventData { get; set; }
        public string Metadata { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
