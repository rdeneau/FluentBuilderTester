namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterWithPagination<out TOrder, out TPagination, out TParameters> :
        ISearchParameterWithOrder<TOrder, TParameters>
    {
        TPagination Pagination { get; }
    }
}
