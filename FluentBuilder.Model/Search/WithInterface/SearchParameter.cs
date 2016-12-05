using System.Runtime.Serialization;

namespace FluentBuilder.Model.Search.WithInterface
{
    [DataContract]
    public class SearchParameter<TOrder, TPagination, TParameters> :
        SearchParameterBase<TOrder, TPagination, TParameters>,
        ISearchParameterWithPagination<TOrder, TPagination, TParameters>
    {
    }
}
