using System.ComponentModel.DataAnnotations;

public class ReportCard
{
    [Key]
    public int reportCardId { get; set; }
    public DateTime time { get; set; }
    public int moneyIn { get; set; }
    public int moneyOut { get; set; }
    public string moneyInSource { get; set; }
    public string moneyOutSource { get; set; }
    public int Total { get; set; }
    public int libId { get; set; }
}
