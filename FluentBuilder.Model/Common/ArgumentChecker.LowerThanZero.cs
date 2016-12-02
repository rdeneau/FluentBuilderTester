using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is lower than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanZero(int value, [InvokerParameterName] string parameterName)
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        [PublicAPI]
        public static void LowerThanZero(long value, [InvokerParameterName] string parameterName)
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanZero(double value, [InvokerParameterName] string parameterName)
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanZero(float value, [InvokerParameterName] string parameterName)
        {
            if (value >= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerZero);
            }
        }
    }
}