using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    [Table("Foods")]
    public class Food : ShopItem
    {
        public double Weight { get; set; }
    }
}