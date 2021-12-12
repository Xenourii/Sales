namespace Sales;

public abstract class Discount
{
    public abstract Percentage DiscountPercentage { get; }

    public abstract Currency Apply(List<Article> articles);

    public static Currency GetTotalPrice(List<Article> articles)
    {
        var sum = articles.Sum(article => article.Price.Value);
        return new Currency(sum);
    }
}

public class MostExpensiveArticleDiscount : Discount
{
    public override Percentage DiscountPercentage { get; }

    public MostExpensiveArticleDiscount(Percentage discountPercentage)
    {
        DiscountPercentage = discountPercentage;
    }

    public override Currency Apply(List<Article> articles)
    {
        if (!articles.Any())
            return new Currency();

        var mostExpensiveArticle = articles.OrderBy(a => a.Price).Last();
        var discountPrice = DiscountPercentage.Of(mostExpensiveArticle.Price);
        return GetTotalPrice(articles) - discountPrice;
    }
}