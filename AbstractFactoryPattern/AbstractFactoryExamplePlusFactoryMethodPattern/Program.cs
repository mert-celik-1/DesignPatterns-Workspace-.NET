
ComputerCreator creator = new();
Computer asus = creator.CreateComputer(ComputerType.Asus);

class Computer
{
    public CPU CPU { get; set; }
    public RAM RAM { get; set; }
    public VideoCard VideoCard { get; set; }

    public Computer(VideoCard videoCard, CPU cPU, RAM rAM)
    {
        VideoCard = videoCard;
        CPU = cPU;
        RAM = rAM;
    }
}

interface ICPU { }
interface IRAM { }
interface IVideoCard { }

class CPU : ICPU
{
    public CPU(string text)
    {
        Console.WriteLine(text);
    }
}

class RAM : IRAM
{
    public RAM(string text)
    {
        Console.WriteLine(text);
    }
}

class VideoCard : IVideoCard
{
    public VideoCard(string text)
    {
        Console.WriteLine(text);
    }
}

interface IComputerFactory
{
    ICPU CreateCpu();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}

class AsusFactory : IComputerFactory
{
    public ICPU CreateCpu()
    {
        return new CPU("Asus Cpu");
    }

    public IRAM CreateRAM()
    {
        return new RAM("Asus RAM");
    }

    public IVideoCard CreateVideoCard()
    {
        return new VideoCard("Asus Video Card");
    }
}

class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCpu()
    {
        return new CPU("Toshiba Cpu");
    }

    public IRAM CreateRAM()
    {
        return new RAM("Toshiba RAM");
    }

    public IVideoCard CreateVideoCard()
    {
        return new VideoCard("Toshiba Video Card");
    }
}

enum ComputerType
{
    Asus,
    Toshiba
}

class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory _computerFactory = computerType switch
        {
            ComputerType.Asus => new AsusFactory(),
            ComputerType.Toshiba => new ToshibaFactory()
        };
        _cpu = _computerFactory.CreateCpu();
        _ram = _computerFactory.CreateRAM();
        _videoCard = _computerFactory.CreateVideoCard();

        return new Computer(_videoCard as VideoCard, _cpu as CPU, _ram as RAM);
    }
}
