using System.Runtime.Serialization;

namespace FluentBuilder.Model.Search
{
    /// <summary>
    /// Used to sort by a field in ascending or descending order.
    /// </summary>
    [DataContract]
    public class OrderParameter<TField> : OrderParameter
    {
        /// <summary>
        /// Field by which sorting.
        /// </summary>
        [DataMember]
        public TField By { get; protected set; }

        protected OrderParameter()
        {
        }

        internal static OrderParameter<TField> PerformCreate(TField orderBy, bool orderAsc)
        {
            return new OrderParameter<TField>
            {
                By  = orderBy,
                Asc = orderAsc
            };
        }
    }
}
