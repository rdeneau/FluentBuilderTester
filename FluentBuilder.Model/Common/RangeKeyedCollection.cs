using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FluentBuilder.Model.Common
{
    /// <summary>
    /// KeyedCollection with the <see cref="AddRange"/> method and
    /// the <see cref="Keys"/> and <see cref="TryGetValue"/> <see cref="Dictionary{TKey,TValue}"/> alike members.
    /// </summary>
    public abstract class RangeKeyedCollection<TKey,TItem> : KeyedCollection<TKey,TItem>
    {
        protected RangeKeyedCollection() { }

        protected RangeKeyedCollection(TItem item)
        {
            Add(item);
        }

        protected RangeKeyedCollection(IEnumerable<TItem> items)
        {
            AddRange(items);
        }

        public void AddRange(IEnumerable<TItem> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public IEnumerable<TKey> Keys => this.Select(GetKeyForItem);

        public bool TryGetValue(TKey key, out TItem item)
        {
            if (Contains(key))
            {
                item = base[key];
                return true;
            }

            item = default(TItem);
            return false;
        }
    }
}