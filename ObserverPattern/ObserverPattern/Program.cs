

var samsung = new Product(1000,"Samsung");

var user = new Observer("Mert");

var amazon = new Amazon();

amazon.Register(user,samsung);

amazon.NotifyForProductName("Samsung");

Console.ReadLine();


class Amazon
{
    private Dictionary<IObserver, Product> observers = new();

    public void Register(IObserver observer, Product product)
    {
        observers.TryAdd(observer, product);
    } 
    public void Unregister(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyAll()
    {
        foreach (var observer in observers)
        {
            observer.Key.StockUpdate(observer.Value);
        }
    }

    public void NotifyForProductName(string productName)
    {
        foreach (var kv in observers)
        {
            if (kv.Value.Name == productName)
                kv.Key.StockUpdate(kv.Value);

        }
    }

}

interface IObserver
{
    void StockUpdate(Product product);
}
class Observer : IObserver
{
    public string FullName { get; set; }

    public Observer(string fullName)
    {
        FullName = fullName;
    }
    
    public void StockUpdate(Product product)
    {
        Console.WriteLine($"{FullName}, {product.Name} in stock now");
    }
}

class Product
{

    public Product(int stock,string name)
    {
        Stock = stock;
        Name = name;
    }

    public int Stock { get; set; }
    public string Name { get; set; }

}