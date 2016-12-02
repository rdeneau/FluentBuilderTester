using System;
using NFluent;
using Xunit;

namespace FluentBuilder.Tests.Common
{
    public partial class StepCheckerTests
    {
        [Trait("UnitTests", "")]
        public class AssertCalledAfterShould
        {
            [Theory]
            [InlineData(Condition.Invalid)]
            [InlineData(Condition.Valid)]
            public void Throw_InvalidOperationException_With_Unknown_Step(bool invalidCondition)
            {
                // Act
                var exception = Record.Exception(() => StepCheckerTested.AssertCalledAfter(StepName.Unknown, invalidCondition));

                // Assert
                Check.That(exception)
                     .IsNotNull()
                     .And.IsInstanceOf<InvalidOperationException>();
            }

            [Theory]
            [InlineData(StepName.Step1)]
            [InlineData(StepName.Step2)]
            [InlineData(StepName.Step3)]
            [InlineData(StepName.Step4)]
            public void Throw_InvalidOperationException_With_Invalid_Condition(string step)
            {
                // Act
                var exception = Record.Exception(() => StepCheckerTested.AssertCalledAfter(step, Condition.Invalid));

                // Assert
                Check.That(exception)
                     .IsNotNull()
                     .And.IsInstanceOf<InvalidOperationException>();
            }

            [Fact]
            public void Throw_InvalidOperationException_With_First_Step()
            {
                // Act
                var exception = Record.Exception(() => StepCheckerTested.AssertCalledAfter(StepName.Step1, Condition.Valid));

                // Assert
                Check.That(exception)
                     .IsNotNull()
                     .And.IsInstanceOf<InvalidOperationException>();
            }

            [Theory]
            [InlineData(StepName.Step2)]
            [InlineData(StepName.Step3)]
            [InlineData(StepName.Step4)]
            public void Pass_Without_Invalid_Condition(string step)
            {
                // Act
                var exception = Record.Exception(() => StepCheckerTested.AssertCalledAfter(step, Condition.Valid));

                // Assert
                Check.That(exception)
                     .IsNull();
            }
        }
    }
}
