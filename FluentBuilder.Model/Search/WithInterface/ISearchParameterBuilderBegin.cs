namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterBuilderBegin<TOrder, TPagination, TParameters>
    {
        ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters> Begin();
    }
}
