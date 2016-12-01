namespace FluentBuilderTester
{
    public interface ISearchParameterBuilderBegin<TParameters> :
        ISearchParameterBuilderFinal<TParameters>
    {
        ISearchParameterBuilderFinalOrPagination<TParameters> With(Order order);
    }
}
