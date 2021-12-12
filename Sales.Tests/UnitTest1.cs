using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Sales.Tests
{
    public class PercentageShould
    {
        [Theory]
        [InlineData(100, 10, 10)]
        [InlineData(75, 10, 7.50)]
        [InlineData(50, 10, 5)]
        [InlineData(25, 10, 2.50)]
        [InlineData(0, 10, 0)]
        public void Correctly_calculate_percentage_of_currency(double percentage, double price, double expected)
        {
            var result = new Percentage(percentage).Of(new Currency(price));
            result.Value.Should().Be(expected);
        }
    }

    public class MostExpensiveArticleDiscountShould
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var articles = new List<Article>
            {
                new() {Price = new Currency(10)},
                new() {Price = new Currency(5)},
                new() {Price = new Currency(20)},
                new() {Price = new Currency(1)}
            };

            // Act
            var discount = new MostExpensiveArticleDiscount(new Percentage(30));
            var finalePrice = discount.Apply(articles);

            // Assert
            finalePrice.Value.Should().Be(30);
        }
    }
}