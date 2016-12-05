namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterBuilder<TOrder, TPagination, TParameters>
    {
        ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters> Begin();
    }
}
