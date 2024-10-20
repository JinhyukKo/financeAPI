namespace FinSharkk.Models;

public class Stock
{
   public int Id { get; set; }
   public string Symbol { get; set; } = string.Empty;
   public string CompanyName { get; set; } = string.Empty;
   public decimal Purchase { get; set; }
   public decimal LastDiv { get; set; }
   public string Industry   { get; set; }  = string.Empty;
   public long MarketCap { get; set; } 
   public List<Comment> Comments { get; set; } =new List<Comment>();
}