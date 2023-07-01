


public interface IProduct
{
    void Run();
}

class A : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public void Run()
    {
        throw new NotImplementedException();
    }
}

enum ProductType
{
    A,B,C
}

public interface IFactory
{
    IProduct CreateProduct();
}

class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        A a = new A();
        return a;
    }
}

class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        B b = new B();
        return b;
    }
}

class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        C c = new C();
        return c;
    }
}



class ProductCreator
{
    static public IProduct GetInstance(ProductType productType)
    {
        IFactory _factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory(),
        };

        return _factory.CreateProduct();

    }

}

