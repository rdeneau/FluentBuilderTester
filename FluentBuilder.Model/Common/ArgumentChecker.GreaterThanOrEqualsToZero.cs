using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is greather than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanOrEqualsToZero(int value, [InvokerParameterName] string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanOrEqualsToZero(long value, [InvokerParameterName] string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanOrEqualsToZero(double value, [InvokerParameterName] string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterOrEqualZero);
            }
        }

        /// <summary>
        /// Checks whether the specified value is greather than or equals to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void GreaterThanOrEqualsToZero(float value, [InvokerParameterName] string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, Messages.GreaterOrEqualZero);
            }
        }
    }
}