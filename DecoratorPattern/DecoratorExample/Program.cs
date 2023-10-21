ICoffee c = new SimpleCoffee();
Console.WriteLine(c.GetCost());
Console.WriteLine(c.GetDescription());

c = new Cappuccino(c);
Console.WriteLine(c.GetCost());
Console.WriteLine(c.GetDescription());

c = new Americano(c);
Console.WriteLine(c.GetCost());
Console.WriteLine(c.GetDescription());

public interface ICoffee
{
    double GetCost();
    string GetDescription();
}

public class SimpleCoffee : ICoffee
{
    public double GetCost() => 25;

    public string GetDescription() => "Sade Kahve";
}

public class Cappuccino : ICoffee
{
    private readonly ICoffee coffee;
    public Cappuccino(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public double GetCost() => this.coffee.GetCost() + 2;

    public string GetDescription() => this.coffee.GetDescription() + " & Milk";
}


public class Americano : ICoffee
{
    private readonly ICoffee coffee;
    public Americano(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public double GetCost() => this.coffee.GetCost() + 3;

    public string GetDescription() => this.coffee.GetDescription() + " & Hot Water";
}