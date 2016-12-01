namespace FluentBuilderTester
{
    public interface ISearchParameterBuilderPagination<TParameters>
    {
        ISearchParameterBuilderFinal<TParameters> With(Pagination pagination);
    }
}
