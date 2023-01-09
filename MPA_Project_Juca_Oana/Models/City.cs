using System.ComponentModel.DataAnnotations;

namespace MPA_Project_Juca_Oana.Models
{
    public class City
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "City Name")]
        [StringLength(50)]
        public string CityName { get; set; }
        public ICollection<StadiumByCity> StadiumByCity { get; set; }
    }
}
