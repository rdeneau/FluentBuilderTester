using System.Runtime.Serialization;
using FluentBuilder.Model.Common;

namespace FluentBuilder.Model.Search.WithMaybe
{
    [DataContract]
    public class SearchParameter<TOrder, TParameters> :
        SearchParameterBase<Maybe<TOrder>, Maybe<PaginationParameter>, Maybe<TParameters>>
        where TOrder : class
        where TParameters : class
    {
    }
}
