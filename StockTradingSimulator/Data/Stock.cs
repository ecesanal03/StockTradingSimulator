using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTradingSimulator.Data
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Symbol { get; set; } = String.Empty;

        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        public decimal CurrentPrice { get; set; } = 0;

        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
