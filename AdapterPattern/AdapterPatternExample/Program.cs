
var trans = new TransferTransaction
{
    Amount = 10,
    ToIban = "you",
    FromIban = "me"
};

var adapter = new JsonBankApiAdapter();
var result = adapter.ExecuteTransaction(trans);

Console.WriteLine(result);

Console.ReadLine();


interface IBankApi
{
    bool ExecuteTransaction(TransferTransaction transferTransaction);
}

class JsonBankApiAdapter : IBankApi
{
    private readonly JsonBankApi _jsonBankApi;

    public JsonBankApiAdapter()
    {
        _jsonBankApi = new();
    }

    public bool ExecuteTransaction(TransferTransaction transferTransaction)
    {
        return _jsonBankApi.Execute(transferTransaction);
    }
}

class JsonBankApi 
{
    public bool Execute(TransferTransaction transferTransaction)
    {
        var xml = $$""""
                {
                    ""FromIban"" : ""{{transferTransaction.FromIban}}"",
                    ""ToIban"" : ""{{transferTransaction.ToIban}}"",
                    ""Amount"" : ""{{transferTransaction.Amount}}""
                }
                """";
        Console.WriteLine($"{GetType().Name} worked");
        return true;
    }
}

class XMLBankApi: IBankApi
{
    public bool ExecuteTransaction (TransferTransaction transferTransaction)
    {
        var xml = $"""
                <TransferTransaction>
                    <FromIban>{transferTransaction.FromIban}</FromIban>
                    <ToIban>{transferTransaction.ToIban}</ToIban>
                    <Amount>{transferTransaction.Amount}</Amount>   
                </TransferTransaction>
                """;
        Console.WriteLine($"{GetType().Name} worked");
        return true;
    }
}

class TransferTransaction
{
    public string FromIban { get; set; }
    public string ToIban { get; set; }
    public decimal Amount { get; set; }

}