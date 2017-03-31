using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourceSample
{
    public class ImportantProcessAggregate
    {
        public ImportantProcessAggregate(IEnumerable<ImportantEvent> events)
        {

        }

        public void CreateAnImportantThing(string name, int age)
        { }

        public void AnotherImportantThingHappenedToTheImportantThing(DateTime when, string how) { }
    }
}
