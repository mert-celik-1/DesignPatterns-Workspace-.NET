
class Example
{
	private Example()
	{
		Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");

	}

	static Example _example;

	public static Example? GetInstance 
	{
		get 
		{ 
			if(_example == null)
				_example = new Example();
			return _example;
		}
	
	}

}