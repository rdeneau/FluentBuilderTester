using System.Runtime.Serialization;
using FluentBuilder.Model.Common;

namespace FluentBuilder.Model.Search
{
    [DataContract]
    public class SearchParameterWithMaybe<TOrder, TParameters> :
        SearchParameter<Maybe<TOrder>, Maybe<PaginationParameter>, Maybe<TParameters>>
        where TOrder : class
        where TParameters : class
    {
    }
}
