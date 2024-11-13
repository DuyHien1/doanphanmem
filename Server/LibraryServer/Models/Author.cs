using System.ComponentModel.DataAnnotations;

public class Author
{
    [Key]
    public string AuthorName { get; set; }
    public string Gender { get; set; }
    public byte Age { get; set; }

    // Navigation property
    //public ICollection<Book> Books { get; set; }
}
