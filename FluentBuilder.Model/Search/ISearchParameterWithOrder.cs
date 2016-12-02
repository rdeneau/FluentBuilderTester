namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterWithOrder<out TOrder, out TParameters> :
        ISearchParameterWithParameters<TParameters>
    {
        TOrder Order { get; }
    }
}
