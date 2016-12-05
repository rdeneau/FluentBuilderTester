namespace FluentBuilder.Tests.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks whether the result type of the method <see cref="fn"/> of the current object
        /// contains all specified methods.
        /// </summary>
        public static bool HasAllMethodsInReturnedType(this object source, string fn, params string[] methodNames)
        {
            return source.HasMethodsInReturnedType(fn, true, methodNames);
        }

        /// <summary>
        /// Checks whether the result type of the method <see cref="fn"/> of the current object
        /// contains at least one the methods specified by their name.
        /// </summary>
        public static bool HasAnyMethodsInReturnedType(this object source, string fn, params string[] methodNames)
        {
            return source.HasMethodsInReturnedType(fn, false, methodNames);
        }

        private static bool HasMethodsInReturnedType(this object source, string fn, bool all, params string[] methodNames)
        {
            var returnType = source?.GetType()
                                    .GetMethod(fn)
                                   ?.ReturnType;
            var result = all;
            foreach (var methodName in methodNames)
            {
                var hasMethod = returnType?.GetMethod(methodName) != null;
                if (!hasMethod && all)
                {
                    return false;
                }
                if (hasMethod && !all)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
