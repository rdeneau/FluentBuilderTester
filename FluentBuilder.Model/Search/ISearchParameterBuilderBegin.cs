namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterBuilderBegin<TOrder, TPagination, TParameters>
    {
        ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters> Begin();
    }
}
