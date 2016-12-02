using System.Collections.Generic;
using System.Linq;
using FluentBuilder.Model.Search;
using NFluent;
using Xunit;

namespace FluentBuilder.Tests.Search
{
    [Trait("UnitTests", "")]
    public class SearchParameterBuilderTests
    {
        #region Classes and Data

        public class FakeParameters
        {
            public string Category { get; set; }
        }

        private class TestedBuilder : SearchParameterBuilder<OrderParameter, PaginationParameter, FakeParameters>
        {
        }

        public static readonly OrderParameter<string>[] Orders =
        {
            null,
            OrderParameter.Create("Name", true)
        };

        public static readonly PaginationParameter[] Paginations =
        {
            null,
            PaginationParameter.CreateTop(3),
            PaginationParameter.CreateFromPage(2, 5)
        };

        public static readonly FakeParameters[] Parameters =
        {
            null,
            new FakeParameters(),
            new FakeParameters { Category = "bike" }
        };

        public static IEnumerable<object[]> OrderData => from param in Parameters
                                                         from order in Orders
                                                         select new object[] { param, order };

        public static IEnumerable<object[]> PaginationData => from param in Parameters
                                                              from order in Orders
                                                              from pagination in Paginations
                                                              select new object[] { param, order, pagination };

        public static IEnumerable<object[]> ParametersData => Parameters.Select(param => new object[] { param })
                                                                        .ToArray();

        #endregion

        #region Test Begin

        [Fact]
        public void Begin_Can_Not_Be_Called_Twice()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var buildr2 = builder.Begin();

            // Assert
            Check.That(buildr2.HasMethod(nameof(builder.Begin)))
                 .IsFalse();
        }

        [Fact]
        public void Begin_Builder_Result_Can_Call_Build_And_WithParameters()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var buildr2 = builder.Begin();

            // Assert
            Check.That(buildr2.HasMethod(nameof(buildr2.Build)))
                 .IsTrue();
            Check.That(buildr2.HasMethod(nameof(buildr2.WithParameters)))
                 .IsTrue();
        }

        #endregion

        #region Test WithParameters

        [Fact]
        public void WithParameters_Can_Not_Be_Called_Twice()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var tmpBuilder = builder.Begin();
            var buildr2 = tmpBuilder.WithParameters(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(tmpBuilder.WithParameters)))
                 .IsFalse();
        }

        [Fact]
        public void WithParameters_Builder_Result_Can_Call_Build_And_WithOrder()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var buildr2 = builder.Begin()
                                       .WithParameters(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(buildr2.Build)))
                 .IsTrue();
            Check.That(buildr2.HasMethod(nameof(buildr2.WithOrder)))
                 .IsTrue();
        }

        [Theory, MemberData(nameof(ParametersData))]
        public void WithParameters_Should_Set_Parameters(FakeParameters parameters)
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var result = builder.Begin()
                                .WithParameters(parameters)
                                .Build();

            // Assert
            Check.That(result.Parameters)
                 .IsEqualTo(parameters);
        }

        #endregion

        #region Test WithOrder

        [Fact]
        public void WithOrder_Can_Not_Be_Called_Twice()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var tmpBuilder = builder.Begin()
                                    .WithParameters(null);
            var buildr2 = tmpBuilder.WithOrder(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(tmpBuilder.WithOrder)))
                 .IsFalse();
        }

        [Fact]
        public void WithOrder_Builder_Result_Can_Call_Build_And_WithPagination()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var buildr2 = builder.Begin()
                                 .WithParameters(null)
                                 .WithOrder(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(buildr2.Build)))
                 .IsTrue();
            Check.That(buildr2.HasMethod(nameof(buildr2.WithPagination)))
                 .IsTrue();
        }

        [Theory, MemberData(nameof(OrderData))]
        public void WithOrder_Should_Set_Order(FakeParameters parameters, OrderParameter<string> order)
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var result = builder.Begin()
                                .WithParameters(parameters)
                                .WithOrder(order)
                                .Build();

            // Assert
            Check.That(result.Parameters)
                 .IsEqualTo(parameters);
            Check.That(result.Order)
                 .IsEqualTo(order);
        }

        #endregion

        #region Test WithPagination

        [Fact]
        public void WithPagination_Can_Not_Be_Called_Twice()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var tmpBuilder = builder.Begin()
                                    .WithParameters(null)
                                    .WithOrder(null);
            var buildr2 = tmpBuilder.WithPagination(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(tmpBuilder.WithPagination)))
                 .IsFalse();
        }

        [Fact]
        public void WithPagination_Builder_Result_Can_Call_Build_Only()
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var buildr2 = builder.Begin()
                                 .WithParameters(null)
                                 .WithOrder(null)
                                 .WithPagination(null);

            // Assert
            Check.That(buildr2.HasMethod(nameof(buildr2.Build)))
                 .IsTrue();
        }

        [Theory, MemberData(nameof(PaginationData))]
        public void WithPagination_Should_Set_Pagination(FakeParameters parameters, OrderParameter<string> order, PaginationParameter pagination)
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var result = builder.Begin()
                                .WithParameters(parameters)
                                .WithOrder(order)
                                .WithPagination(pagination)
                                .Build();

            // Assert
            Check.That(result.Parameters)
                 .IsEqualTo(parameters);
            Check.That(result.Order)
                 .IsEqualTo(order);
            Check.That(result.Pagination)
                 .IsEqualTo(pagination);
        }

        #endregion
    }

    public static class SearchParameterBuilderTestsHelper
    {
        public static bool HasMethod(this object obj, string methodName)
        {
            // Note : the real object has the method. Check only its interfaces
            var interfaces = obj.GetType()
                                .GetInterfaces()
                                .Where(i => i.GetMethod(methodName) != null)
                                .ToList();
            return interfaces.Any();
        }
    }
}
