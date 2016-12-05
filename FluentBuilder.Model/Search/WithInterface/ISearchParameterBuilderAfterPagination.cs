namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterBuilderAfterPagination<out TOrder, out TPagination, out TParameters>
    {
        ISearchParameterWithPagination<TOrder, TPagination, TParameters> Build();
    }
}
