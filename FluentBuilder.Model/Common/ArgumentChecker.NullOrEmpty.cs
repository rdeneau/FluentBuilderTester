﻿using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is null.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <exception cref="ArgumentException">Thrown when the value is <code>null</code></exception>
        [ContractAnnotation("value:null => halt")]
        public static void IsNull([CanBeNull] object value, [InvokerParameterName] string parameterName)
        {
            if (value != null)
            {
                throw new ArgumentNullException(parameterName, Messages.Null);
            }
        }

        /// <summary>
        /// Checks whether the specified <see cref="string"/> value is null or empty.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <exception cref="ArgumentException">Thrown when the value is <code>null</code> or equals to <see cref="string.Empty"/></exception>
        [ContractAnnotation("value:null => halt")]
        public static void IsNullOrEmpty([CanBeNull] string value, [InvokerParameterName] string parameterName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(parameterName, Messages.NullOrEmpty);
            }
        }

        /// <summary>
        /// Checks whether the specified <see cref="Guid"/> value is empty.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <exception cref="ArgumentException">Thrown when the value is equal to <see cref="Guid.Empty"/></exception>
        public static void IsEmptyGuid(Guid value, [InvokerParameterName] string parameterName)
        {
            if (value != Guid.Empty)
            {
                throw new ArgumentException(Messages.EmptyGuid, parameterName);
            }
        }
    }
}