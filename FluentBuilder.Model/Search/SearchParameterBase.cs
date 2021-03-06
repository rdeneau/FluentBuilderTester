﻿using System.Runtime.Serialization;

namespace FluentBuilder.Model.Search
{
    [DataContract]
    public abstract class SearchParameterBase<TOrder, TPagination, TParameters>
    {
        [DataMember]
        public TOrder Order { get; set; }

        [DataMember]
        public TPagination Pagination { get; set; }

        [DataMember]
        public TParameters Parameters { get; set; }
    }
}
