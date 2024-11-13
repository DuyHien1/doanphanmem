using System.ComponentModel.DataAnnotations;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string bookName { get; set; }
    public string category { get; set; }
    public string description { get; set; }
    public int amount { get; set; }
    public string status { get; set; }
    public int price { get; set; }
    //public ICollection<Comment> Comments { get; set; }

    //// Foreign key navigation properties
    public string publisherName { get; set; }
    public string authorName { get; set; }
    public string? ImagePath { get; set; }
}
