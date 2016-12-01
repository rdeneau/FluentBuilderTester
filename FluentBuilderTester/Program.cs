using System;

namespace FluentBuilderTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchParametersLogger.Init();

            SearchParameterBuilder
                .Begin("simple")
                .Build()
                .Log();

            SearchParameterBuilder
                .Begin("withOrder")
                .With(new Order())
                .Build()
                .Log();

            SearchParameterBuilder
                .Begin("withPagination")
                .With(new Order())
                .With(new Pagination())
                .Build()
                .Log();

            //SearchParameterBuilder
            //    .Begin("Impossible")
            //    .With(new Pagination()) // Only Order authorised
            //    .Build()
            //    .Log();

            Console.WriteLine(SearchParametersLogger.Message);
            Console.ReadLine();
        }
    }
}
