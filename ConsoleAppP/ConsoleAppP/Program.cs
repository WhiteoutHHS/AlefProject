

public class VendingMachine
{
    public string Name { get; set; }
    public decimal CashBalance { get; private set; }
    public int WaterStock { get; private set; }
    public int CoffeeStock { get; private set; }
    public int MilkStock { get; private set; }
    public int SugarStock { get; private set; }
    public decimal SalesTotal { get; private set; }

    public VendingMachine(string name, decimal initialCash, int initialWater, int initialCoffee, int initialMilk, int initialSugar)
    {
        Name = name;
        CashBalance = initialCash;
        WaterStock = initialWater;
        CoffeeStock = initialCoffee;
        MilkStock = initialMilk;
        SugarStock = initialSugar;
        SalesTotal = 0;
    }

    public void AcceptCoins(decimal amount)
    {
        if (amount > 0)
        {
            CashBalance += amount;
            Console.WriteLine($"Добавлено {amount:C}. Текущий баланс: {CashBalance:C}");
        }
        else
        {
            Console.WriteLine("Сумма должна быть положительной.");
        }
    }

    public decimal GiveChange(decimal amount)
    {
        if (amount > CashBalance)
        {
            Console.WriteLine("Недостаточно наличных для выдачи сдачи.");
            return 0;
        }

        CashBalance -= amount;
        Console.WriteLine($"Выдана сдача: {amount:C}. Текущий баланс: {CashBalance:C}");
        return amount;
    }

    // Метод для покупки американо
    public void BuyAmericano(bool addSugar)
    {
        if (WaterStock < 1 || CoffeeStock < 1)
        {
            InformAboutIssues();
            return;
        }

        WaterStock--;
        CoffeeStock--;
        SalesTotal += 2.50m; // Примерная цена

        if (addSugar && SugarStock > 0)
        {
            SugarStock--;
        }

        Console.WriteLine("Куплен американо. Продажи: " + SalesTotal.ToString("C"));
    }

  

    private void InformAboutIssues()
    {
        if (CashBalance <= 0)
            Console.WriteLine("Недостаточно наличных в автомате.");

        if (WaterStock <= 0)
            Console.WriteLine("Вода закончилась.");

        if (CoffeeStock <= 0)
            Console.WriteLine("Кофе закончилось.");

        if (MilkStock <= 0)
            Console.WriteLine("Молоко закончилось.");

        if (SugarStock <= 0)
            Console.WriteLine("Сахар закончился.");
    }

    public void Restock(int water, int coffee, int milk, int sugar)
    {
        WaterStock += water;
        CoffeeStock += coffee;
        MilkStock += milk;
        SugarStock += sugar;

        Console.WriteLine("Запасы обновлены.");
    }
}

