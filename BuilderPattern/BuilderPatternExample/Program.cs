ReportDirector director = new ReportDirector();

// PDF rapor oluşturucu
IReportBuilder pdfBuilder = new PdfReportBuilder();
director.SetReportBuilder(pdfBuilder);

// PDF rapor oluştur
var pdfReport = director.BuildReport(
    "Günlük Satış Raporu",
    "Satışlarımızın günlük raporu.",
    new List<string> { "Ürün A - 100 adet", "Ürün B - 75 adet", "Ürün C - 50 adet" },
    "Toplam: 225 adet"
);
pdfReport.Display();

// HTML rapor oluşturucu
IReportBuilder htmlBuilder = new HtmlReportBuilder();
director.SetReportBuilder(htmlBuilder);

// HTML rapor oluştur
var htmlReport = director.BuildReport(
    "Aylık Finansal Rapor",
    "Aylık finansal verilerimiz.",
    new List<string> { "Gelir: $50,000", "Gider: $30,000", "Kar: $20,000" },
    "Net Kar: $20,000"
);
htmlReport.Display();

Console.ReadLine();


// Rapor sınıfı
public class Report
{
    public string Title { get; set; }
    public string Header { get; set; }
    public List<string> Body { get; set; }
    public string Footer { get; set; }

    public void Display()
    {
        Console.WriteLine($"--- {Title} ---");
        Console.WriteLine($"Header: {Header}");

        Console.WriteLine("Body:");
        foreach (var line in Body)
        {
            Console.WriteLine(line);
        }

        Console.WriteLine($"Footer: {Footer}");
        Console.WriteLine("------------------");
    }
}

// Builder arayüzü
public interface IReportBuilder
{
    void SetTitle(string title);
    void SetHeader(string header);
    void AddBodyLine(string line);
    void SetFooter(string footer);
    Report GetReport();
}


// PDF rapor oluşturucu
public class PdfReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetTitle(string title)
    {
        _report.Title = title;
    }

    public void SetHeader(string header)
    {
        _report.Header = header;
    }

    public void AddBodyLine(string line)
    {
        if (_report.Body == null)
        {
            _report.Body = new List<string>();
        }
        _report.Body.Add(line);
    }

    public void SetFooter(string footer)
    {
        _report.Footer = footer;
    }

    public Report GetReport()
    {
        return _report;
    }
}

// HTML rapor oluşturucu
public class HtmlReportBuilder : IReportBuilder
{
    private Report _report = new Report();

    public void SetTitle(string title)
    {
        _report.Title = title;
    }

    public void SetHeader(string header)
    {
        _report.Header = header;
    }

    public void AddBodyLine(string line)
    {
        if (_report.Body == null)
        {
            _report.Body = new List<string>();
        }
        _report.Body.Add($"<p>{line}</p>");
    }

    public void SetFooter(string footer)
    {
        _report.Footer = footer;
    }

    public Report GetReport()
    {
        return _report;
    }
}

// Rapor yöneticisi
public class ReportDirector
{
    private IReportBuilder _reportBuilder;

    public void SetReportBuilder(IReportBuilder builder)
    {
        _reportBuilder = builder;
    }

    public Report BuildReport(string title, string header, List<string> body, string footer)
    {
        _reportBuilder.SetTitle(title);
        _reportBuilder.SetHeader(header);
        foreach (var line in body)
        {
            _reportBuilder.AddBodyLine(line);
        }
        _reportBuilder.SetFooter(footer);

        return _reportBuilder.GetReport();
    }
}

