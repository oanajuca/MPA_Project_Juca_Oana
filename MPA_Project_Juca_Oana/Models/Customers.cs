using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MPA_Project_Juca_Oana.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}
