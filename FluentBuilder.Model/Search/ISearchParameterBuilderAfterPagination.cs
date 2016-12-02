namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterBuilderAfterPagination<out TOrder, out TPagination, out TParameters>
    {
        ISearchParameterWithPagination<TOrder, TPagination, TParameters> Build();
    }
}
