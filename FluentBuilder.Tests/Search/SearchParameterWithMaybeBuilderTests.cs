using System;
using System.Collections.Generic;
using System.Linq;
using FluentBuilder.Model.Search;
using NFluent;
using Xunit;

namespace FluentBuilder.Tests.Search
{
    [Trait("UnitTests", "")]
    public class SearchParameterWithMaybeBuilderTests
    {
        #region Classes and Data

        public class FakeParameters
        {
            public string Category { get; set; }
        }

        private class TestedBuilder : SearchParameterWithMaybeBuilder<OrderParameter, FakeParameters>
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
        public void Begin_Should_Throw_InvalidOperationException_When_Called_Twice()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .Begin());
        }

        #endregion

        #region Test WithParameters

        [Fact]
        public void WithParameters_Should_Throw_InvalidOperationException_When_Called_Before_Begin()
        {
            Assert_Throw_InvalidOperationException(builder => builder.WithParameters(null));
        }

        [Fact]
        public void WithParameters_Should_Throw_InvalidOperationException_When_Called_Twice()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithParameters(null)
                                                                     .WithParameters(null));
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
            Check.That(result.Parameters.HasValue)
                 .IsTrue();
            Check.That(result.Parameters.Value)
                 .IsEqualTo(parameters);

            Check.That(result.Order.HasValue)
                 .IsFalse();
            Check.That(result.Pagination.HasValue)
                 .IsFalse();
        }

        #endregion

        #region Test WithOrder

        [Fact]
        public void WithOrder_Should_Throw_InvalidOperationException_When_Called_Before_Begin()
        {
            Assert_Throw_InvalidOperationException(builder => builder.WithOrder(null));
        }

        [Fact]
        public void WithOrder_Should_Throw_InvalidOperationException_When_Called_Before_WithParameters()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithOrder(null));
        }

        [Fact]
        public void WithOrder_Should_Throw_InvalidOperationException_When_Called_Twice()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithParameters(null)
                                                                     .WithOrder(null)
                                                                     .WithOrder(null));
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
            Check.That(result.Parameters.HasValue)
                 .IsTrue();
            Check.That(result.Parameters.Value)
                 .IsEqualTo(parameters);

            Check.That(result.Order.HasValue)
                 .IsTrue();
            Check.That(result.Order.Value)
                 .IsEqualTo(order);

            Check.That(result.Pagination.HasValue)
                 .IsFalse();
        }

        #endregion

        #region Test WithPagination

        [Fact]
        public void WithPagination_Should_Throw_InvalidOperationException_When_Called_Before_Begin()
        {
            Assert_Throw_InvalidOperationException(builder => builder.WithPagination(null));
        }

        [Fact]
        public void WithPagination_Should_Throw_InvalidOperationException_When_Called_Before_WithParameters()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithPagination(null));
        }

        [Fact]
        public void WithPagination_Should_Throw_InvalidOperationException_When_Called_Before_WithOrder()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithParameters(null)
                                                                     .WithPagination(null));
        }

        [Fact]
        public void WithPagination_Should_Throw_InvalidOperationException_When_Called_Twice()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Begin()
                                                                     .WithParameters(null)
                                                                     .WithOrder(null)
                                                                     .WithPagination(null)
                                                                     .WithPagination(null));
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
            Check.That(result.Parameters.HasValue)
                 .IsTrue();
            Check.That(result.Parameters.Value)
                 .IsEqualTo(parameters);

            Check.That(result.Order.HasValue)
                 .IsTrue();
            Check.That(result.Order.Value)
                 .IsEqualTo(order);

            Check.That(result.Pagination.HasValue)
                 .IsTrue();
            Check.That(result.Pagination.Value)
                 .IsEqualTo(pagination);
        }

        #endregion

        #region Test Build

        [Fact]
        public void Build_Should_Throw_InvalidOperationException_When_Called_Before_Begin()
        {
            Assert_Throw_InvalidOperationException(builder => builder.Build());
        }

        #endregion

        #region Internal Helpers

        private static void Assert_Throw_InvalidOperationException<TResult>(Func<TestedBuilder, TResult> build)
        {
            // Arrange
            var builder = new TestedBuilder();

            // Act
            var exception = Record.Exception(() => build(builder));

            // Assert
            Check.That(exception)
                 .IsNotNull()
                 .And.IsInstanceOf<InvalidOperationException>();
        }

        #endregion
    }
}
