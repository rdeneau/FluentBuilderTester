namespace FluentBuilderTester
{
    public interface ISearchParameterBuilderFinalOrPagination<TParameters> :
        ISearchParameterBuilderPagination<TParameters>,
        ISearchParameterBuilderFinal<TParameters>
    {
    }
}
