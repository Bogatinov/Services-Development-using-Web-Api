using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Invoice 
    {
        public Invoice()
        {
            Items = new HashSet<ShopItem>();
            Tickets = new HashSet<Ticket>();
        }
        public ICollection<ShopItem> Items { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public double Price { get; set; }
    }
}