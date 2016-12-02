using System;
using System.Runtime.Serialization;
using FluentBuilder.Model.Common;

namespace FluentBuilder.Model.Search
{
    [DataContract]
    public class PaginationParameter
    {
        /// <summary>
        /// Indice de la première ligne inclue de la page, à partir de 0.
        /// </summary>
        [DataMember]
        public int StartIndex { get; private set; }

        /// <summary>
        /// Indice de la dernière ligne inclue de la page, à partir de 0.
        /// Doit être supérieur ou égal à <see cref="StartIndex"/>.
        /// </summary>
        [DataMember]
        public int EndIndex { get; private set; }

        /// <summary>
        /// Numéro de la page, à partir de 1 (avec <see cref="StartIndex"/> &#8805; 0).
        /// </summary>
        [DataMember]
        public int PageNumber { get; private set; }

        /// <summary>
        /// Taille des pages, en nombre de lignes.
        /// </summary>
        [DataMember]
        public int PageSize { get; private set; }

        private PaginationParameter(int startIndex, int endIndex, int pageNumber, int pageSize)
        {
            StartIndex = startIndex;
            EndIndex   = endIndex;
            PageNumber = pageNumber;
            PageSize   = pageSize;
        }

        public int ComputePageCount(int rowCount)
        {
            return ComputePageCount(rowCount, PageSize);
        }

        public static int ComputePageCount(int rowCount, int pageSize)
        {
            ArgumentChecker.GreaterThanZero(pageSize, nameof(pageSize));
            return (int)Math.Ceiling(Convert.ToDouble(rowCount) / Convert.ToDouble(pageSize));
        }

        public static int ComputeStartIndex(int pageNumber, int pageSize)
        {
            return (pageNumber - 1) * pageSize;
        }

        public static int ComputeEndIndex(int pageNumber, int pageSize)
        {
            return pageNumber * pageSize - 1;
        }

        public static PaginationParameter CreateFromIndex(int startIndex, int endIndex)
        {
            ArgumentChecker.GreaterThanOrEqualsTo(endIndex, startIndex, nameof(endIndex));

            var pageSize = endIndex - startIndex + 1;
            var pageNumber = (endIndex + 1) / pageSize;

            return new PaginationParameter(startIndex, endIndex, pageNumber, pageSize);
        }

        public static PaginationParameter CreateFromPage(int pageNumber, int pageSize)
        {
            ArgumentChecker.GreaterThanZero(pageNumber, nameof(pageNumber));
            ArgumentChecker.GreaterThanZero(pageSize, nameof(pageSize));

            return new PaginationParameter(
                ComputeStartIndex(pageNumber, pageSize),
                ComputeEndIndex(pageNumber, pageSize),
                pageNumber, pageSize);
        }

        public static PaginationParameter CreateTop(int top)
        {
            return CreateFromPage(1, top);
        }
    }
}
