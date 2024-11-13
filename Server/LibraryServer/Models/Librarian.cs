using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Librarian
{
    [Key]
    public int LibId { get; set; }
    public string LibName { get; set; }
    public DateTime Birthday { get; set; }
    public string Address { get; set; }
    [ForeignKey("UserId")]
    public Account userId { get; set; }
}
