using System.Collections.Generic;
using FluentBuilder.Model.Common;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Search.WithMaybe
{
    public class SearchParameterBuilder<TOrder, TParameters>
        where TOrder : class
        where TParameters : class
    {
        protected Maybe<SearchParameter<TOrder, TParameters>> ResultWrapper { get; private set; }

        protected bool HasResult                              => ResultWrapper.HasValue;
        protected bool HasNoResult                            => ResultWrapper.HasNoValue;
        protected SearchParameter<TOrder, TParameters> Result => ResultWrapper.Value;

        public SearchParameterBuilder<TOrder, TParameters> Begin()
        {
            _stepChecker.AssertCalledOnce(nameof(Begin), HasResult);
            ResultWrapper = new SearchParameter<TOrder, TParameters>();
            return this;
        }

        public SearchParameterBuilder<TOrder, TParameters> WithParameters([CanBeNull] TParameters parameters)
        {
            _stepChecker.AssertCalledAfter(nameof(WithParameters), HasNoResult);
            _stepChecker.AssertCalledOnce (nameof(WithParameters), Result.Parameters.HasValue);
            Result.Parameters = parameters;
            return this;
        }

        public SearchParameterBuilder<TOrder, TParameters> WithOrder([CanBeNull] TOrder order)
        {
            _stepChecker.AssertCalledAfter(nameof(WithOrder), Result.Parameters.HasNoValue);
            _stepChecker.AssertCalledOnce (nameof(WithOrder), Result.Order.HasValue);
            Result.Order = order;
            return this;
        }

        public SearchParameterBuilder<TOrder, TParameters> WithPagination([CanBeNull] PaginationParameter pagination)
        {
            _stepChecker.AssertCalledAfter(nameof(WithPagination), Result.Order.HasNoValue);
            _stepChecker.AssertCalledOnce (nameof(WithPagination), Result.Pagination.HasValue);
            Result.Pagination = pagination;
            return this;
        }

        public SearchParameter<TOrder, TParameters> Build()
        {
            _stepChecker.AssertCalledAfter(nameof(Build), HasNoResult);
            return Result;
        }

        #region StepChecker

        private readonly StepChecker<string> _stepChecker = new StepChecker<string>(ComputeSteps());

        /// <summary>
        /// Create steps with their previous step, with one particular feature:
        /// The previous step of the last step is the first.
        /// </summary>
        public static IEnumerable<ChainedItem<string>> ComputeSteps()
        {
            var steps = new[]
            {
                nameof(Begin),
                nameof(WithParameters),
                nameof(WithOrder),
                nameof(WithPagination),
                nameof(Build)
            };

            var stepLastIndex = steps.Length - 1;
            var chainedSteps = new List<ChainedItem<string>> { ChainedItem.CreateFirst(steps[0]) };
            for (var stepIndex = 1; stepIndex < stepLastIndex; stepIndex++)
            {
                chainedSteps.Add(ChainedItem.Create(steps[stepIndex], steps[stepIndex - 1]));
            }
            chainedSteps.Add(ChainedItem.Create(steps[stepLastIndex], steps[0]));

            return chainedSteps;
        }

        #endregion
    }
}
