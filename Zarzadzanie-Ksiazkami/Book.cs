using System;

public abstract class Book
{
	public int Id {  get; set; }
	public string Title { get; set; }
	public string Author { get; set; }
	public string Genre { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishedDate { get; set; }

	public abstract string GetFormat();
}

public class PrintedBook : Book
{
	public int PageCount { get; set; }
    public override string GetFormat()
    {
		return "Printed";
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
