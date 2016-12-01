namespace FluentBuilderTester
{
    public interface ISearchParameters<TParameters>
    {
        TParameters Parameters { get; }
        Order Order { get; }
        Pagination Pagination { get; }
    }
}
