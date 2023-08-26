using static Editor;

List<Document> documents = new List<Document>()
                {
                    new Document() { Id = 1, TextContent = new string('*', 500)},
                    new Document() { Id = 2, TextContent = new string('*', 850)},
                    new Document() { Id = 3, TextContent = new string('*', 1500)},
                    new Document() { Id = 4, TextContent = new string('*', 2500) }
                };

IEditor editor = new Editor();
IEditor executiveEditor = new ExecutiveEditor();
IEditor managingEditor = new ManagingEditor();

editor.SetSuccessor(executiveEditor);
executiveEditor.SetSuccessor(managingEditor);


documents.ForEach(x =>
{
    var result = editor.ReviewDocument(x);
    Console.WriteLine(result.Approved ? "Document {0} approved by {1}"
        : "Document {0} rejected by {1}",
                      x.Id, result.Reviewer);
});
Console.Read();



//Entity
public class Document
{
    public string? TextContent { get; set; }
    public int Id { get; set; }
}

//Return edilecek class
public class ReviewResult
{
    public bool Approved { get; set; }
    public string? Reviewer { get; set; }
}

public abstract class IEditor
{
    protected IEditor successor;

    public void SetSuccessor(IEditor successor)
    {
        this.successor = successor;
    }

    public abstract ReviewResult ReviewDocument(Document document);
}

public class Editor : IEditor
{
    public override ReviewResult ReviewDocument(Document document)
    {
        ReviewResult result = new ReviewResult()
        {
            Reviewer = "Editor"
        };
        if (!string.IsNullOrWhiteSpace(document.TextContent))
        {
            if (document.TextContent.Length > 1000)
                return successor.ReviewDocument(document);
            if (document.TextContent.Length >= 600)
                result.Approved = true;
        }
        return result;
    }

    public class ExecutiveEditor : IEditor
    {
        public override ReviewResult ReviewDocument(Document document)
        {
            ReviewResult result = new ReviewResult()
            {
                Reviewer = "Executive Editor"
            };
            if (!string.IsNullOrWhiteSpace(document.TextContent))
            {
                if (document.TextContent.Length > 2000)
                    return successor.ReviewDocument(document);
                if (document.TextContent.Length <= 1500)
                    result.Approved = false;
                if (document.TextContent.Length > 1500)
                    result.Approved = true;
            }
            return result;
        }
    }

    public class ManagingEditor : IEditor
    {
        public override ReviewResult ReviewDocument(Document document)
        {
            ReviewResult result = new ReviewResult()
            {
                Reviewer = "Managing Editor"
            };
            result.Approved = !string.IsNullOrWhiteSpace(document.TextContent) && document.TextContent.Length > 2000;
            return result;
        }
    }
}


