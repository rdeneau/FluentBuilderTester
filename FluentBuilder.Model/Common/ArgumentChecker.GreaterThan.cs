using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is greather than the minLimit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="minLimit">The min limit.</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThan<T>(T value, T minLimit, [InvokerParameterName] string parameterName)
        {
            var strValue = value as string;
            if (strValue != null)
            {
                GreaterThan(strValue, minLimit as string, parameterName, StringComparer.CurrentCulture);
            }
            else
            {
                GreaterThan(value, minLimit, parameterName, Comparer<T>.Default);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than the minLimit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="minLimit">The min limit.</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="comparer">The comparer.</param>
        [PublicAPI]
        public static void GreaterThan<T>(T value, T minLimit, [InvokerParameterName] string parameterName, IComparer<T> comparer)
        {
            IsNotNull(comparer, nameof(comparer));

            if (comparer.Compare(value, minLimit) <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, string.Format(CultureInfo.CurrentCulture, Messages.Greater, minLimit));
            }
        }
    }
}