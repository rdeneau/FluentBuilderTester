using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is lower than or equals to the maxLimit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="maxLimit">The min limit.</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanOrEqualsTo<T>(T value, T maxLimit, [InvokerParameterName] string parameterName)
        {
            var stringValue = value as string;
            if (stringValue != null)
            {
                LowerThanOrEqualsTo(stringValue, maxLimit as string, parameterName, StringComparer.CurrentCulture);
            }
            else
            {
                LowerThanOrEqualsTo(value, maxLimit, parameterName, Comparer<T>.Default);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than or equals to the maxLimit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="maxLimit">The min limit.</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="comparer">The comparer.</param>
        [PublicAPI]
        public static void LowerThanOrEqualsTo<T>(T value, T maxLimit, [InvokerParameterName] string parameterName, IComparer<T> comparer)
        {
            IsNotNull(comparer, nameof(comparer));

            if (comparer.Compare(value, maxLimit) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value,
                    string.Format(CultureInfo.CurrentCulture, Messages.LowerOrEqual, maxLimit));
            }
        }
    }
}