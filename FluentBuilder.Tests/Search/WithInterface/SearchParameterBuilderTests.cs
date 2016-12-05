using System.Collections.Generic;
using System.Linq;
using FluentBuilder.Model.Search;
using FluentBuilder.Model.Search.WithInterface;
using FluentBuilder.Tests.Extensions;
using NFluent;
using Xunit;

namespace FluentBuilder.Tests.Search.WithInterface
{
    [Trait("UnitTests", "")]
    public class SearchParameterBuilderTests
    {
        #region Data

        public class FakeParameters
        {
            public string Category { get; set; }
        }

        public ISearchParameterBuilder<OrderParameter, PaginationParameter, FakeParameters> CreateBuilder()
        {
            return SearchParameterBuilder<OrderParameter, PaginationParameter, FakeParameters>.Create();
        }

        public static class MethodNames
        {
            public static readonly string Begin;
            public static readonly string Build;
            public static readonly string CreateBuilder;
            public static readonly string WithParameters;
            public static readonly string WithOrder;
            public static readonly string WithPagination;

            static MethodNames()
            {
                var builder1 = SearchParameterBuilder<OrderParameter, PaginationParameter, FakeParameters>.Create();
                var builder2 = builder1.Begin();
                var builder3 = builder2.WithParameters(null);
                var builder4 = builder3.WithOrder(null);
                builder4.Build();

                Begin          = nameof(builder1.Begin);
                Build          = nameof(builder2.Build);
                CreateBuilder  = nameof(CreateBuilder);
                WithParameters = nameof(builder2.WithParameters);
                WithOrder      = nameof(builder3.WithOrder);
                WithPagination = nameof(builder4.WithPagination);
            }

            public static string[] AllBut(params string[] names)
            {
                var nameSet = names.ToHashSet();

                return new[]
                {
                    Begin,
                    Build,
                    CreateBuilder,
                    WithParameters,
                    WithOrder,
                    WithPagination
                }
                .Where(name => !nameSet.Contains(name))
                .ToArray();
            }
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

        #region Facts

        [Fact]
        public void Create_Builder_Result_Can_Call_Begin_Only()
        {
            Check.That(this.HasAllMethodsInReturnedType(MethodNames.CreateBuilder, MethodNames.Begin))
                 .IsTrue();
            Check.That(this.HasAnyMethodsInReturnedType(MethodNames.CreateBuilder, MethodNames.AllBut(MethodNames.Begin)))
                 .IsFalse();
        }

        [Fact]
        public void Begin_Builder_Result_Can_Call_Build_And_WithParameters_Only()
        {
            // Arrange
            var builder = CreateBuilder();

            // Assert
            Check.That(builder.HasAllMethodsInReturnedType(MethodNames.Begin, MethodNames.Build, MethodNames.WithParameters))
                 .IsTrue();
            Check.That(builder.HasAnyMethodsInReturnedType(MethodNames.Begin, MethodNames.AllBut(MethodNames.Build, MethodNames.WithParameters)))
                 .IsFalse();
        }

        [Fact]
        public void WithParameters_Builder_Result_Can_Call_Build_And_WithOrder_Only()
        {
            // Arrange
            var builder = CreateBuilder();

            // Act
            var tmpBuilder = builder.Begin();

            // Assert
            Check.That(tmpBuilder.HasAllMethodsInReturnedType(MethodNames.WithParameters, MethodNames.Build, MethodNames.WithOrder))
                 .IsTrue();
            Check.That(tmpBuilder.HasAnyMethodsInReturnedType(MethodNames.WithParameters, MethodNames.AllBut(MethodNames.Build, MethodNames.WithOrder)))
                 .IsFalse();
        }

        [Theory, MemberData(nameof(ParametersData))]
        public void WithParameters_Should_Set_Parameters(FakeParameters parameters)
        {
            // Arrange
            var builder = CreateBuilder();

            // Act
            var result = builder.Begin()
                                .WithParameters(parameters)
                                .Build();

            // Assert
            Check.That(result.Parameters)
                 .IsEqualTo(parameters);
        }

        [Fact]
        public void WithOrder_Builder_Result_Can_Call_Build_And_WithPagination_Only()
        {
            // Arrange
            var builder = CreateBuilder();

            // Act
            var tmpBuilder = builder.Begin()
                                    .WithParameters(null);

            // Assert
            Check.That(tmpBuilder.HasAllMethodsInReturnedType(MethodNames.WithOrder, MethodNames.Build, MethodNames.WithPagination))
                 .IsTrue();
            Check.That(tmpBuilder.HasAnyMethodsInReturnedType(MethodNames.WithOrder, MethodNames.AllBut(MethodNames.Build, MethodNames.WithPagination)))
                 .IsFalse();
        }

        [Theory, MemberData(nameof(OrderData))]
        public void WithOrder_Should_Set_Order(FakeParameters parameters, OrderParameter<string> order)
        {
            // Arrange
            var builder = CreateBuilder();

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

        [Fact]
        public void WithPagination_Builder_Result_Can_Call_Build_Only()
        {
            // Arrange
            var builder = CreateBuilder();

            // Act
            var tmpBuilder = builder.Begin()
                                    .WithParameters(null)
                                    .WithOrder(null);

            // Assert
            Check.That(tmpBuilder.HasAllMethodsInReturnedType(MethodNames.WithPagination, MethodNames.Build))
                 .IsTrue();
            Check.That(tmpBuilder.HasAnyMethodsInReturnedType(MethodNames.WithPagination, MethodNames.AllBut(MethodNames.Build)))
                 .IsFalse();
        }

        [Theory, MemberData(nameof(PaginationData))]
        public void WithPagination_Should_Set_Pagination(FakeParameters parameters, OrderParameter<string> order, PaginationParameter pagination)
        {
            // Arrange
            var builder = CreateBuilder();

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
}
