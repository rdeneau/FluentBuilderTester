using FluentBuilder.Model.Common;

namespace FluentBuilder.Model.Search
{
    public class OrderParameterSet<TField> : RangeKeyedCollection<TField, OrderParameter<TField>>
    {
        protected override TField GetKeyForItem(OrderParameter<TField> item)
        {
            return item.By;
        }
    }
}
