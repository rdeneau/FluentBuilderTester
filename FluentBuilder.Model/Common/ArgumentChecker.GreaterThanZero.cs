using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is greather than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanZero(int value, [InvokerParameterName] string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanZero(long value, [InvokerParameterName] string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanZero(double value, [InvokerParameterName] string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanZero(float value, [InvokerParameterName] string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterZero);
            }
        }
    }
}