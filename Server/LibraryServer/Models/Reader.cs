using System.ComponentModel.DataAnnotations;

public class Reader
{
    [Key]
    public int ReaderId { get; set; }  // Changed to PascalCase for consistency
    public string ReaderName { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public Account UserId { get; set; }  // Assuming Account is another entity

    // Navigation property for the one-to-one relationship
    public ReaderCard ReaderCard { get; set; }
}
