using System.Runtime.Serialization;

namespace FluentBuilder.Model.Search
{
    [DataContract]
    public class OrderParameter
    {
        /// <summary>
        /// Indicates whether the order is ascending or descending.
        /// </summary>
        [DataMember]
        public bool Asc { get; protected set; }

        protected OrderParameter()
        {
            Asc = true;
        }

        public static OrderParameter<TField> Create<TField>(TField orderBy, bool orderAsc)
        {
            return OrderParameter<TField>.PerformCreate(orderBy, orderAsc);
        }
    }
}
