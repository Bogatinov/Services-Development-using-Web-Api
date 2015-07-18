using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    [Table("Movies")]
    public class Movie
    {
        public Movie()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
        public double Rating { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}