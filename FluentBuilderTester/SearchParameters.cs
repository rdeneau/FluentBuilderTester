namespace FluentBuilderTester
{
    public class SearchParameters<TParameters> : ISearchParameters<TParameters>
    {
        public TParameters Parameters { get; set; }
        public Order Order { get; set; }
        public Pagination Pagination { get; set; }

        public override string ToString()
        {
            var result = $"Parameters={Parameters}";
            if (Order != null)
            {
                result += $", Ordered";
            }
            if (Pagination != null)
            {
                result += $", Paginated";
            }
            return result;
        }
    }
}
