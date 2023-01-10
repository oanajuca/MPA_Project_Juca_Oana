namespace MPA_Project_Juca_Oana.Models
{
    public class Teams
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public Trainers? Traners { get; set; }

        public Players? Players { get; set; }
    }
}
