using System;

namespace FluentBuilderTester
{
    public static class SearchParameterBuilder
    {
        public static ISearchParameterBuilderBegin<TParameters> Begin<TParameters>(TParameters parameters)
        {
            return new SearchParameterBuilder<TParameters>(parameters);
        }
    }

    /// <summary>
    /// Enchainements autorisés :
    ///   Après Begin()
    ///     With(Order)
    ///     Build()
    ///   
    ///   Après With(Order)
    ///     With(Pagination)
    ///     Build()
    ///   
    ///   Après With(Pagination)
    ///     Build()
    /// </summary>
    public class SearchParameterBuilder<TParameters> :
        ISearchParameterBuilderBegin<TParameters>,
        ISearchParameterBuilderFinalOrPagination<TParameters>
    {
        private SearchParameters<TParameters> Result { get; }

        public SearchParameterBuilder(TParameters parameters)
        {
            Result = new SearchParameters<TParameters> { Parameters = parameters };
        }

        public ISearchParameterBuilderFinalOrPagination<TParameters> With(Order order)
        {
            Result.Order = order;
            return this;
        }

        public ISearchParameterBuilderFinal<TParameters> With(Pagination pagination)
        {
            Result.Pagination = pagination;
            return this;
        }

        public SearchParameters<TParameters> Build()
        {
            return Result;
        }
    }
}
