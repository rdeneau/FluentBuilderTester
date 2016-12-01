namespace FluentBuilderTester
{
    public interface ISearchParameterBuilderFinal<TParameters>
    {
        SearchParameters<TParameters> Build();
    }
}
