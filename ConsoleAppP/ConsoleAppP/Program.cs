
public class VendingMachine
{
    public VendingMachine(string name, decimal initialCash, int initialWater, int initialCoffee, int initialMilk, int initialSugar)
    {
        name = name;
        cashBalance = initialCash;
        waterStock = initialWater;
        coffeeStock = initialCoffee;
        milkStock = initialMilk;
        sugarStock = initialSugar;
        salesTotal = 0;
    }

    public string name { get; set; }
    public decimal cashBalance { get; private set; }
    public int waterStock { get; private set; }
    public int coffeeStock { get; private set; }
    public int milkStock { get; private set; }
    public int sugarStock { get; private set; }
    public decimal salesTotal { get; private set; }


    public void AcceptCoins(decimal amount)
    {
        if (amount > 0)
        {
            cashBalance += amount;
            Console.WriteLine($"Добавлено {amount:C}. Текущий баланс: {cashBalance:C}");
        }
        else
        {
            Console.WriteLine("Сумма должна быть положительной.");
        }
    }

    public decimal GiveChange(decimal amount)
    {
        if (amount > cashBalance)
        {
            Console.WriteLine("Недостаточно наличных для выдачи сдачи.");
            return 0;
        }

        cashBalance -= amount;
        Console.WriteLine($"Выдана сдача: {amount:C}. Текущий баланс: {cashBalance:C}");
        return amount;
    }

    // Метод для покупки американо
    public void BuyAmericano(bool addSugar)
    {
        if (waterStock < 1 || coffeeStock < 1)
        {
            InformAboutIssues();
            return;
        }

        waterStock--;
        coffeeStock--;
        salesTotal += 2.50m;

        if (addSugar && sugarStock > 0)
        {
            sugarStock--;
        }

        Console.WriteLine("Куплен американо. Продажи: " + salesTotal.ToString("C"));
    }
    // Метод для покупки капучино
    public void BuyCappuccino(bool addSugar)
    {
        if (waterStock < 1 || coffeeStock < 1 || milkStock < 1)
        {
            InformAboutIssues();
            return;
        }

        waterStock--;
        coffeeStock--;
        milkStock--;
        salesTotal += 3.00m;

        if (addSugar && sugarStock > 0)
        {
            sugarStock--;
        }

        Console.WriteLine("Куплен капучино. Продажи: " + salesTotal.ToString("C"));
    }

    // Метод для покупки латте
    public void BuyLatte(bool addSugar)
    {
        if (waterStock < 1 || coffeeStock < 1 || milkStock < 2)
        {
            InformAboutIssues();
            return;
        }

        waterStock--;
        coffeeStock--;
        milkStock -= 2; // Латте требует больше молока
        salesTotal += 3.50m;

        if (addSugar && sugarStock > 0)
        {
            sugarStock--;
        }

        Console.WriteLine("Куплен латте. Продажи: " + salesTotal.ToString("C"));
    }


    private void InformAboutIssues()
    {
        if (cashBalance <= 0)
            Console.WriteLine("Недостаточно наличных в автомате.");

        if (waterStock <= 0)
            Console.WriteLine("Вода закончилась.");

        if (coffeeStock <= 0)
            Console.WriteLine("Кофе закончилось.");

        if (milkStock <= 0)
            Console.WriteLine("Молоко закончилось.");

        if (sugarStock <= 0)
            Console.WriteLine("Сахар закончился.");
    }

    public void Restock(int water, int coffee, int milk, int sugar)
    {
        waterStock += water;
        coffeeStock += coffee;
        milkStock += milk;
        sugarStock += sugar;

        Console.WriteLine("Запасы обновлены.");
    }
}

