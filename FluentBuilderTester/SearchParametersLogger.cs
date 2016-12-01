using System;

namespace FluentBuilderTester
{
    public static class SearchParametersLogger
    {
        public static string Message { get; private set; }

        public static void Init()
        {
            Message = "Starting";
        }

        public static void Log<TParameters>(this SearchParameters<TParameters> source)
        {
            Message += Environment.NewLine + $"Building {source}";
        }
    }
}
