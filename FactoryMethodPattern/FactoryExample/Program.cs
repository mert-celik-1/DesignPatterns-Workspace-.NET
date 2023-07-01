
var a = ProductCreator.GetInstance(ProductType.A) as A;
a.Run();

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
    A, B, C
}


class ProductCreator
{
    static public IProduct GetInstance(ProductType productType)
    {
        IProduct _product = null;

        switch (productType)
        {
            case ProductType.A:
                _product = new A();
                break;
            case ProductType.B:
                _product = new B();
                break;
            case ProductType.C:
                _product = new C();
                break;

        }

        return _product;

    }

}