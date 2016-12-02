namespace FluentBuilder.Model.Common
{
    /// <summary>
    /// Class to check whether a method argument aka input parameter satisfy some usual conditions.
    /// </summary>
    public static partial class ArgumentChecker
    {
        private static class Messages
        {
            public const string ComparerNotNull    = "The comparer cannot be null.";
            public const string Defined            = "The value '{0}' is not defined in the enum type '{1}'.";
            public const string DefinedType        = "TEnum must be an enumerated type.";
            public const string Equal              = "The argument must be equal to {0}.";
            public const string EqualToZero        = "The argument must be equal to 0.";
            public const string ExistsNotFound     = "The specified path {0} doesn't exist.";
            public const string Greater            = "The argument must be strictly greater than {0}.";
            public const string GreaterOrEqual     = "The argument must be greater than or equal to {0}.";
            public const string GreaterOrEqualZero = "The argument must be greater than or equal to 0.";
            public const string GreaterZero        = "The argument must be strictly greater than 0.";
            public const string Lower              = "The argument must be strictly lower than {0}.";
            public const string LowerOrEqual       = "The argument must be lower than or equal to {0}.";
            public const string LowerOrEqualZero   = "The argument must be lower than or equal to 0.";
            public const string LowerZero          = "The argument must be strictly lower than 0.";
            public const string EmptyGuid          = "The argument must be an empty Guid.";
            public const string Null               = "The argument must be null.";
            public const string NullOrEmpty        = "The argument must be null or empty.";
            public const string NotEmptyGuid       = "The argument cannot be an empty Guid.";
            public const string NotNull            = "The argument cannot be null.";
            public const string NotNullOrEmpty     = "The argument cannot be null or empty.";
        }
    }
}