// Comment.cs

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]
    public int CommentId { get; set; }

    [Required]
    public string Text { get; set; }

    // Foreign key for User
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    //public Account Account { get; set; }

    // Foreign key for Book
    public int BookId { get; set; }
    //[ForeignKey(nameof(BookId))]
    //public Book Book { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Set default value

}
