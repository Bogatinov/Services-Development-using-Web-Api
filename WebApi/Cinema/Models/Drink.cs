using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [Table("Drinks")]
    public class Drink : ShopItem
    {
        public double Liters { get; set; }
    }
}