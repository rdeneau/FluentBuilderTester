using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is equal to the reference value.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="referenceValue">The reference value.</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void EqualsTo<T>(T value, T referenceValue, [InvokerParameterName] string parameterName)
        {
            var strValue = value as string;
            if (strValue != null)
            {
                EqualsTo(strValue, referenceValue as string, parameterName, StringComparer.CurrentCulture);
            }
            else
            {
                EqualsTo(value, referenceValue, parameterName, Comparer<T>.Default);
            }
        }

        /// <summary>
        /// Checks whether the specified value is equal to the reference value.
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The parameter value to check</param>
        /// <param name="referenceValue">The reference value.</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="comparer">The comparer.</param>
        public static void EqualsTo<T>(T value, T referenceValue, [InvokerParameterName] string parameterName, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), Messages.ComparerNotNull);
            }
            if (comparer.Compare(value, referenceValue) != 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Messages.Equal, referenceValue),
                    parameterName);
            }
        }
    }
}