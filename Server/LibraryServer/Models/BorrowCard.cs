using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BorrowCard
{
    [Key]
    public int brcardId { get; set; }

    [ForeignKey("UserId")]
    public int userId { get; set; }

    [ForeignKey("BookId")]
    public int bookId { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime Expidate { get; set; }
    public Account Account { get; set; }
}
