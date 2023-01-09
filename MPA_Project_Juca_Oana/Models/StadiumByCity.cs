using System.Security.Policy;

namespace MPA_Project_Juca_Oana.Models
{
    public class StadiumByCity
    {
        public int CityID { get; set; }
        public int StadiumID { get; set; }
        public City City { get; set; }
        public Stadiums Stadium { get; set; }
    }
}
