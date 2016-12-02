using System;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks whether the specified value is equal to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void EqualsToZero(int value, [InvokerParameterName] string parameterName)
        {
            if (value != 0)
            {
                throw new ArgumentException(Messages.EqualToZero, parameterName);
            }
        }

        /// <summary>
        /// Checks whether the specified value is equal to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void EqualsToZero(long value, [InvokerParameterName] string parameterName)
        {
            if (value != 0)
            {
                throw new ArgumentException(Messages.EqualToZero, parameterName);
            }
        }

        /// <summary>
        /// Checks whether the specified value is equal to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void EqualsToZero(double value, [InvokerParameterName] string parameterName)
        {
            if (Math.Abs(value - 0) > double.Epsilon)
            {
                throw new ArgumentException(Messages.EqualToZero, parameterName);
            }
        }

        /// <summary>
        /// Checks whether the specified value is equal to zero.
        /// </summary>
        /// <param name="value">The parameter value to check</param>
        /// <param name="parameterName">Name of the parameter</param>
        public static void EqualsToZero(float value, [InvokerParameterName] string parameterName)
        {
            if (Math.Abs(value - 0) > float.Epsilon)
            {
                throw new ArgumentException(Messages.EqualToZero, parameterName);
            }
        }
    }
}