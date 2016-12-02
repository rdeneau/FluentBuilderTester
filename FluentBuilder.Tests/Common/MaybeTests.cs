using FluentBuilder.Model.Common;
using NFluent;
using Xunit;

namespace FluentBuilder.Tests.Common
{
    [Trait("UnitTests", "")]
    public class MaybeTests
    {
        public abstract class MaybeFacts<T> where T : class
        {
            [Fact]
            public void HasValue_Should_Be_True_With_Null_Inner_Value()
            {
                // Arrange and act
                Maybe<T> maybe = null;

                // Assert
                Check.That(maybe.HasValue)
                     .IsEqualTo(true);
            }

            [Fact]
            public void HasNoValue_Should_Be_True_By_Default_With_String()
            {
                // Arrange and act
                var maybe = new Maybe<T>();

                // Assert
                Check.That(maybe.HasNoValue)
                     .IsEqualTo(true);
            }
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        public class EmptyObject { }

        public class MaybeFactsForObject : MaybeFacts<EmptyObject> { }
        public class MaybeFactsForString : MaybeFacts<string> { }
    }
}
