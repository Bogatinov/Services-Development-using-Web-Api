using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public int MovieId { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; }
    }
}