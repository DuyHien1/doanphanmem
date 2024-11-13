using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReaderCard
{
    [Key]
    public int CardId { get; set; }  // Changed to PascalCase for consistency
    public DateTime DateCreated { get; set; }
    public DateTime ExpDate { get; set; }

    // Foreign key property
    public int ReaderId { get; set; }

    // Navigation property for the one-to-one relationship
    [ForeignKey("ReaderId")]
    public Reader Reader { get; set; }
}
