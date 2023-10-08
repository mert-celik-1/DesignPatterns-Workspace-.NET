
var paymentOpt = new PaymentOptions
{
    CardHolderName = "Mert",
    CardNumber = "1",
    ExpiryDate = "12/25",
    Cvv = "123",
    Amount = 12
};


var service = new PaymentService();

while (true)
{
    Console.WriteLine("Ödeme yapılacak bankayı seç. 1-Garanti 2-Iş Bank");
    var bank = Console.ReadLine();

    IPaymentService bankPaymentService = null;

    switch (bank)
    {
        case "1":
            bankPaymentService = new GarantiBankPaymentService();
            break;
        case "2":
            bankPaymentService = new IsBankPaymentService();
            break;
        default:
            Console.WriteLine("Geçersiz banka");
            break;
    }

    service.SetPaymentService(bankPaymentService);
    service.PayViaStrategy(paymentOpt);

}

class PaymentService
{
    private IPaymentService _paymentService;

    public PaymentService()
    {

    }

    public PaymentService(IPaymentService paymentService)
    {
        this._paymentService = paymentService;
    }

    public void SetPaymentService(IPaymentService paymentService)
    {
        this._paymentService = paymentService;
    }

    public bool PayViaStrategy(PaymentOptions opt)
    {
        return _paymentService.Pay(opt);
    }
}

class GarantiBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions opt)
    {
        Console.WriteLine("Garanti Bankası ödeme yapıld");
        return true;
    }
}

class IsBankPaymentService : IPaymentService
{
    public bool Pay(PaymentOptions opt)
    {
        Console.WriteLine("Is Bankası ödeme yapıld");
        return true;
    }
}

interface IPaymentService
{
    bool Pay(PaymentOptions opt);

}


public class PaymentOptions
{
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpiryDate { get; set; }
    public string Cvv { get; set; }
    public decimal Amount { get; set; }
}