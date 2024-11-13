using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReturnCard
{
    [Key]
    public int reCardId { get; set; }
    public DateTime ReturnDate { get; set; }


    // Foreign key navigation property
    [ForeignKey("PhieuMuonSach")]
    public BorrowCard brcardId { get; set; }
}
