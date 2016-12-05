using JetBrains.Annotations;

namespace FluentBuilder.Model.Search.WithInterface
{
    public interface ISearchParameterBuilderAfterOrder<out TOrder, TPagination, out TParameters>
    {
        ISearchParameterWithOrder<TOrder, TParameters> Build();
        ISearchParameterBuilderAfterPagination<TOrder, TPagination, TParameters> WithPagination([CanBeNull] TPagination pagination);
    }
}
