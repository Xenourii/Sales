// See https://aka.ms/new-console-template for more information

using Sales;

var cart = new ShoppingCart
{
    Discount = new MostExpensiveArticleDiscount(new Percentage(30)),
    Articles = new List<Article>
    {
        new() {Price = new Currency(50)},
        new() {Price = new Currency(300)},
        new() {Price = new Currency(20)}
    }
};

var totalPrice = cart.GetTotalPrice();
Console.WriteLine($"Total price is {totalPrice}");


public class Article
{
    public Currency Price { get; set; } = new();
}

public class ShoppingCart
{
    public List<Article> Articles { get; set; } = new();

    public Discount? Discount { get; set; }

    public Currency GetTotalPrice()
    {
        if (Discount is null)
            return new Currency(Articles.Sum(a => a.Price.Value));

        return Discount.Apply(Articles);
    }
}