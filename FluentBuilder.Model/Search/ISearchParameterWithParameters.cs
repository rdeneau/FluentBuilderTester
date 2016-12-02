namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterWithParameters<out TParameters> : ISearchParameter
    {
        TParameters Parameters { get; }
    }
}
