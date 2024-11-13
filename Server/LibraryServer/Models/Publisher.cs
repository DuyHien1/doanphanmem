using System.ComponentModel.DataAnnotations;

public class Publisher
{
    [Key]
    public string publisherName { get; set; }
    public string address { get; set; }

    // Navigation property
    //public ICollection<Book> Books { get; set; }
}
