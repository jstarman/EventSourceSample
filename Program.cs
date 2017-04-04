using NEventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Wireup.Init()
                .LogToConsoleWindow()
                .UsingSqlPersistence("EventStore")
                .WithDialect(new MsSqlDialect)

        }
    }
}
