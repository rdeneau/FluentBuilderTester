﻿using JetBrains.Annotations;

namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterBuilderAfterParameters<TOrder, TPagination, out TParameters>
    {
        ISearchParameterWithParameters<TParameters> Build();
        ISearchParameterBuilderAfterOrder<TOrder, TPagination, TParameters> WithOrder([CanBeNull] TOrder order);
    }
}
