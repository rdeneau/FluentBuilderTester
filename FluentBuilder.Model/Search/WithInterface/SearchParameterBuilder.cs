namespace FluentBuilder.Model.Search.WithInterface
{
    public class SearchParameterBuilder       <TOrder, TPagination, TParameters> :
        ISearchParameterBuilder               <TOrder, TPagination, TParameters>,
        ISearchParameterBuilderAfterBegin     <TOrder, TPagination, TParameters>,
        ISearchParameterBuilderAfterParameters<TOrder, TPagination, TParameters>,
        ISearchParameterBuilderAfterOrder     <TOrder, TPagination, TParameters>,
        ISearchParameterBuilderAfterPagination<TOrder, TPagination, TParameters>
    {
        protected SearchParameter<TOrder, TPagination, TParameters> Result { get; private set; }

        protected SearchParameterBuilder() { }

        public static ISearchParameterBuilder<TOrder, TPagination, TParameters> Create()
        {
            return new SearchParameterBuilder<TOrder, TPagination, TParameters>();
        }

        public ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters> Begin()
        {
            Result = new SearchParameter<TOrder, TPagination, TParameters>();
            return this;
        }

        public ISearchParameterBuilderAfterParameters<TOrder, TPagination, TParameters> WithParameters(TParameters parameters)
        {
            Result.Parameters = parameters;
            return this;
        }

        public ISearchParameterBuilderAfterOrder<TOrder, TPagination, TParameters> WithOrder(TOrder order)
        {
            Result.Order = order;
            return this;
        }

        public ISearchParameterBuilderAfterPagination<TOrder, TPagination, TParameters> WithPagination(TPagination pagination)
        {
            Result.Pagination = pagination;
            return this;
        }

        public ISearchParameter Build()
        {
            return Result;
        }

        ISearchParameterWithParameters<TParameters> ISearchParameterBuilderAfterParameters<TOrder, TPagination, TParameters>.Build()
        {
            return Result;
        }

        ISearchParameterWithOrder<TOrder, TParameters> ISearchParameterBuilderAfterOrder<TOrder, TPagination, TParameters>.Build()
        {
            return Result;
        }

        ISearchParameterWithPagination<TOrder, TPagination, TParameters> ISearchParameterBuilderAfterPagination<TOrder, TPagination, TParameters>.Build()
        {
            return Result;
        }
    }
}
