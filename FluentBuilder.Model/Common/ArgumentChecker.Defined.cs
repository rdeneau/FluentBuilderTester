using System;
using System.Globalization;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks if the specified value is defined in the enum type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="parameterName">The name of the parameter.</param>
        [PublicAPI]
#pragma warning disable CS3024 // Constraint type is not CLS-compliant
        public static void IsDefined<TEnum>(TEnum value, [InvokerParameterName] string parameterName)
#pragma warning restore CS3024 // Constraint type is not CLS-compliant
            where TEnum : struct, IConvertible
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
            {
                throw new ArgumentException(Messages.DefinedType);
            }
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Messages.Defined, value, enumType), parameterName);
            }
        }
    }
}