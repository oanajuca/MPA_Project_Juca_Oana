using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MPA_Project_Juca_Oana.Models
{
    public class Stadiums
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }

        public Teams? Teams { get; set; }
        public int? TeamID { get; set; }
        public ICollection<Orders>? Orders { get; set; }

        public ICollection<StadiumByCity>? StadiumByCity { get; set; }

    }
}
