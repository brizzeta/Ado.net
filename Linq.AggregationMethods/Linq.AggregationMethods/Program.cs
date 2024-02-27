class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main()
    {
        List<Good> goods = new List<Good>()
        {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good() { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };

        // 1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.
        var expensiveMobileGoods = goods.Where(good => good.Category == "Mobile" && good.Price > 1000);
        Console.WriteLine("Expensive Mobile Goods:");
        foreach (var good in expensiveMobileGoods)
        {
            Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
        }

        // 2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen, цена которых превышает 1000 грн.
        var expensiveNonKitchenGoods = goods.Where(good => good.Category != "Kitchen" && good.Price > 1000);
        Console.WriteLine("\nExpensive Goods Not in Kitchen Category:");
        foreach (var good in expensiveNonKitchenGoods)
        {
            Console.WriteLine($"Title: {good.Title}, Price: {good.Price}");
        }

        // 3) Вычислить среднее значение всех цен товаров.
        var averagePrice = goods.Average(good => good.Price);
        Console.WriteLine($"\nAverage Price of Goods: {averagePrice}");

        // 4) Вывести список категорий без повторений.
        var uniqueCategories = goods.Select(good => good.Category).Distinct();
        Console.WriteLine("\nUnique Categories:");
        foreach (var category in uniqueCategories)
        {
            Console.WriteLine(category);
        }

        // 5) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по названию.
        var goodsSortedByName = goods.OrderBy(good => good.Title);
        Console.WriteLine("\nGoods Sorted by Name:");
        foreach (var good in goodsSortedByName)
        {
            Console.WriteLine($"Title: {good.Title}, Category: {good.Category}");
        }

        // 6) Посчитать суммарное количество товаров категорий Car и Mobile.
        var totalCarAndMobileGoods = goods.Count(good => good.Category == "Car" || good.Category == "Mobile");
        Console.WriteLine($"\nTotal Car and Mobile Goods: {totalCarAndMobileGoods}");

        // 7) Вывести список категорий и количество товаров каждой категории.
        var goodsByCategory = goods.GroupBy(good => good.Category)
                                    .Select(group => new { Category = group.Key, Count = group.Count() });
        Console.WriteLine("\nGoods Count by Category:");
        foreach (var group in goodsByCategory)
        {
            Console.WriteLine($"Category: {group.Category}, Count: {group.Count}");
        }
    }
}
