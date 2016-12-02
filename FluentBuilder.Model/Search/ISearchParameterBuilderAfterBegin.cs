﻿using JetBrains.Annotations;

namespace FluentBuilder.Model.Search
{
    public interface ISearchParameterBuilderAfterBegin<TOrder, TPagination, TParameters>
    {
        ISearchParameter Build();
        ISearchParameterBuilderAfterParameters<TOrder, TPagination, TParameters> WithParameters([CanBeNull] TParameters parameters);
    }
}
