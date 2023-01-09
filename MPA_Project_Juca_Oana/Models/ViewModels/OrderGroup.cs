using System;
using System.ComponentModel.DataAnnotations;

namespace MPA_Project_Juca_Oana.Models.ViewModels
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int StadiumsCount { get; set; }
    }
}
