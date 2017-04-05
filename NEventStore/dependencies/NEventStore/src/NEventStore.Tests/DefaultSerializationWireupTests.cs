﻿namespace NEventStore
{
    using NEventStore.Persistence.AcceptanceTests;
    using NEventStore.Persistence.AcceptanceTests.BDD;
    using System;
    using Xunit;
    using Xunit.Should;

    public class DefaultSerializationWireupTests
    {
        public class when_building_an_event_store_without_an_explicit_serializer : SpecificationBase
        {
            private Wireup _wireup;
            private Exception _exception;
            private IStoreEvents _eventStore;
            protected override void Context()
            {
                _wireup = Wireup.Init()
                    .UsingInMemoryPersistence();
            }

            protected override void Because()
            {
                _exception = Catch.Exception(() => { _eventStore = _wireup.Build(); });
            }

            protected override void Cleanup()
            {
                _eventStore.Dispose();
            }

            [Fact]
            public void should_not_throw_an_argument_null_exception()
            {
                _exception.ShouldNotBeInstanceOf<ArgumentNullException>();
            }
        }
    }
}
