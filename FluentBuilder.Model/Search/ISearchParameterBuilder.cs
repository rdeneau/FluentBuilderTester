namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterBuilder<TOrder, TPagination, TParameters>
    {
        ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters> Begin();
    }
}
