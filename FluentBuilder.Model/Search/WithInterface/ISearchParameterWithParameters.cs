namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterWithParameters<out TParameters> : ISearchParameter
    {
        TParameters Parameters { get; }
    }
}
