using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MPA_Project_Juca_Oana.Models
{
    public class Orders
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int StadiumID { get; set; }
        public DateTime OrderDate { get; set; }


        public Customers? Customers { get; set; }
        public Stadiums? Stadiums { get; set; }
    }
}
