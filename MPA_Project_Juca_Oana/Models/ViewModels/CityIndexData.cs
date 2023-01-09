using System.Security.Policy;

namespace MPA_Project_Juca_Oana.Models.ViewModels
{
    public class CityIndexData
    {
        public IEnumerable<City> City { get; set; }
        public IEnumerable<Stadiums> Stadiums { get; set; }
        public IEnumerable<Orders> Orders { get; set; }

    }
}
