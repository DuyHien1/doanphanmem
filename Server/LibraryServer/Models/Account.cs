// Models/TaiKhoan.cs
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Account
{
    [Key]
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTime DateCreated { get; set; }
    public BorrowCard BorrowCard { get; set; }
    //public ICollection<Comment> Comments { get; set; }
}

