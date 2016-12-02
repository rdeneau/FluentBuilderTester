using System.Globalization;
using System.IO;
using JetBrains.Annotations;

namespace FluentBuilder.Model.Common
{
    public static partial class ArgumentChecker
    {
        /// <summary>
        /// Checks if the specified <see cref="FileInfo "/> <paramref name="file"/> exists.
        /// </summary>
        /// <param name="file">The file.</param>
        [PublicAPI]
        public static void Exists(FileSystemInfo file)
        {
            IsNotNull(file, nameof(file));

            file.Refresh();
            if (!file.Exists)
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, Messages.ExistsNotFound,
                    file.FullName));
            }
        }
    }
}