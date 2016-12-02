using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public class StepChecker<TStep> where TStep : class
    {
        /// <summary>
        /// Dictionary giving all steps and their possible previous step.
        /// </summary>
        private Dictionary<TStep, Maybe<TStep>> Steps { get; }

        public StepChecker(IEnumerable<ChainedItem<TStep>> steps)
        {
            Steps = steps.ToDictionary(
                step => step.Current,
                step => step.Previous);
        }

        [AssertionMethod]
        public void AssertCalledAfter(TStep currentStep, bool invalidCondition)
        {
            var previousStep = GetPreviousStep(currentStep);
            Assert(invalidCondition, $"{currentStep} must be called after {previousStep} !");
        }

        [AssertionMethod]
        public void AssertCalledOnce(TStep step, bool invalidCondition)
        {
            AssertKnownStep(step);
            Assert(invalidCondition, $"{step} can be called only once !");
        }

        private void AssertKnownStep(TStep step)
        {
            if (!Steps.ContainsKey(step))
            {
                throw new InvalidOperationException($"Unknown step {step} !");
            }
        }

        private TStep GetPreviousStep(TStep currentStep)
        {
            AssertKnownStep(currentStep);
            var previousStep = Steps[currentStep];
            if (previousStep.HasNoValue)
            {
                throw new InvalidOperationException($"Step {currentStep} does not have a previous step !");
            }
            return previousStep.Value;
        }

        /// <summary>
        /// Throw an <see cref="InvalidOperationException"/>
        /// with the specified <see cref="message"/>
        /// when the specified <see cref="invalidCondition"/> happened.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        [AssertionMethod]
        private static void Assert(bool invalidCondition, string message)
        {
            if (invalidCondition)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
