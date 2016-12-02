using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is lower than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanOrEqualsToZero(int value, [InvokerParameterName] string parameterName)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        [PublicAPI]
        public static void LowerThanOrEqualsToZero(long value, [InvokerParameterName] string parameterName)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanOrEqualsToZero(double value, [InvokerParameterName] string parameterName)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is lower than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void LowerThanOrEqualsToZero(float value, [InvokerParameterName] string parameterName)
        {
            if (value > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.LowerOrEqualZero);
            }
        }
    }
}