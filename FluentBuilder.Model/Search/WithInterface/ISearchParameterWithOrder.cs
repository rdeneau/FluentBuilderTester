namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterWithOrder<out TOrder, out TParameters> :
        ISearchParameterWithParameters<TParameters>
    {
        TOrder Order { get; }
    }
}
