
ComputerCreator creator = new();
Computer asus = creator.CreateComputer(new AsusFactory());  

class Computer
{
    public CPU CPU { get; set; }
    public RAM RAM { get; set; }
    public VideoCard VideoCard { get; set; }

    public Computer(VideoCard videoCard,CPU cPU,RAM rAM)
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

class RAM :IRAM
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

class Toshiba : IComputerFactory
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


class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer (IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCpu();
        _ram = computerFactory.CreateRAM();
        _videoCard= computerFactory.CreateVideoCard();

        return new Computer(_videoCard as VideoCard,_cpu as CPU,_ram as RAM);
    }
}
