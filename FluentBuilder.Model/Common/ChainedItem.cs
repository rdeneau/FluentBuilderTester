namespace FluentBuilder.Model.Common
{
    public class ChainedItem<TItem> where TItem : class
    {
        public TItem Current { get; }
        public Maybe<TItem> Previous { get; }

        public ChainedItem(TItem current, Maybe<TItem> previous)
        {
            Current = current;
            Previous = previous;
        }
    }

    public static class ChainedItem
    {
        public static ChainedItem<TItem> Create<TItem>(TItem current, TItem previous) where TItem : class
        {
            return new ChainedItem<TItem>(current, previous);
        }

        public static ChainedItem<TItem> CreateFirst<TItem>(TItem current) where TItem : class
        {
            return new ChainedItem<TItem>(current, new Maybe<TItem>());
        }
    }
}
