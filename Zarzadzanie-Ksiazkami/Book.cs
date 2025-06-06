using System;
using System.Text.Json;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(EBook), "EBook")]
[JsonDerivedType(typeof(PrintedBook), "PrintedBook")]
public abstract class Book
{
	public int Id {  get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }

	public abstract string GetFormat();

    [JsonIgnore]
    public string BookType => GetFormat();
    [JsonIgnore]
    public string Details =>
        this is PrintedBook printed ? $"{printed.PageCount} stron" :
        this is EBook eb ? $"Format: {eb.FileFormat}" :
        "";
}

public class PrintedBook : Book
{
	public int PageCount { get; set; }
    public override string GetFormat()
    {
		return "Fizyczna";
    }
}

public class EBook : Book
{
	public string FileFormat { get; set; }
    public override string GetFormat()
    {
		return "EBook";
    }
}

public interface IRepository<T>
{
	void Add(T item);
	void Remove(int id);
	void Update(T item);
	T GetById(int id);
	List<T> GetAll();
}

public class BookRepository : IRepository<Book>
{
    private List<Book> _books;

    public BookRepository() 
    { 
        var _filePath = AppConfig.Instance.FilePath;
        if (string.IsNullOrWhiteSpace(_filePath))
        {
            _books = new List<Book>();
        } 
        else
        {
            _books = Load();
        }
    }

    public void Add(Book book)
    {
        book.Id = AppConfig.Instance.GetNextId();
        _books.Add(book);
        Save(_books);
    }

    private void Save(List<Book> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        });

        var filePath = AppConfig.Instance.FilePath;

        if (string.IsNullOrWhiteSpace(filePath))
        {
            filePath = "book.json";
            //throw new InvalidOperationException("Ścieżka do pliku z książkami jest pusta lub niezdefiniowana.");
        }
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Zapisuję do: {Path.GetFullPath(filePath)}");
    }

    public void SaveAll()
    {
        Save(_books);
    }

    public void SetBooks(List<Book> books)
    {
        _books = books;
    }

    public List<Book> GetAll()
    {
        return _books;
    }

    public Book GetById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            throw new BookNotFoundException(id);
        return book;
    }

    public void Remove(int id)
    {
        _books.RemoveAll(b => b.Id == id);
        Save(_books);
    }

    public void Update(Book updatedBook)
    {
        var index = _books.FindIndex(b => b.Id == updatedBook.Id);
        if (index != -1)
        {
            _books[index] = updatedBook;
            Save(_books);
        }
    }

    public List<Book> Load()
    {
        var filePath = AppConfig.Instance.FilePath;
        if (!File.Exists(filePath)) return new List<Book>();
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions 
    {
        WriteIndented = true,
        Converters = {new JsonStringEnumConverter()}
    };
}

public class BookNotFoundException : Exception
{
    public BookNotFoundException(int id) : base($"Książka o ID {id} nie została znaleziona.") { }
}
