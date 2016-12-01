namespace FluentBuilderTester
{
    public interface ISearchParameterBuilderOrder<TParameters> :
        ISearchParameterBuilderPagination<TParameters>,
        ISearchParameterBuilderFinal<TParameters>
    {
    }
}
