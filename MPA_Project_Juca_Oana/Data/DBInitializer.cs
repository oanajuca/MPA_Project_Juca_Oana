using Microsoft.EntityFrameworkCore;
using MPA_Project_Juca_Oana;
using MPA_Project_Juca_Oana.Models;

namespace MPA_Project_Juca_Oana.Data
{
    public class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                if (context.Stadiums.Any())
                {
                    return; // BD a fost creata anterior
                }
                context.Stadiums.AddRange(
                new Stadiums
                {
                    Name="Camp Nou",
                    Location="Barcelona, Spain",
                    Price=Decimal.Parse("58")},

                 new Stadiums
                 {
                     Name="Estadio Santiago Bernabeu",
                     Location="Madrid, Spain",
                     Price=Decimal.Parse("56")
                 },

                new Stadiums
                {
                    Name="Wanda Metropolitano",
                    Location="Madrid, Spain",
                    Price=Decimal.Parse("60")
                },
                 new Stadiums
                 {
                     Name="Allianz Arena",
                     Location="Munich, Germany",
                     Price=Decimal.Parse("52")
                 },
                  new Stadiums
                  {
                      Name="Etihad Stadium",
                      Location="Manchester, UK",
                      Price=Decimal.Parse("55")
                  },
                   new Stadiums
                   {
                       Name="Old Trafford",
                       Location="Manchester, UK",
                       Price=Decimal.Parse("50")
                   }

                );


                context.Customers.AddRange(
                new Customers
                {
                    Name="Alexander Smith",
                    Adress="Str. AbbeyRoad, nr. 24",
                    BirthDate=DateTime.Parse("1979-09-01")
                },
                new Customers
                {
                    Name="Popescu Adrian",
                    Adress="Str. Bucuresti, nr.45",
                    BirthDate=DateTime.Parse("1999-07-08")}
               
                
                );
                var orders = new Orders[]
 {
 new Orders{StadiumID=1,CustomerID=1,OrderDate=DateTime.Parse("2021-02-25")},
 new Orders{StadiumID=3,CustomerID=2,OrderDate=DateTime.Parse("2021-09-28")},
 new Orders{StadiumID=1,CustomerID=2,OrderDate=DateTime.Parse("2021-10-28")},
 new Orders{StadiumID=2,CustomerID=1,OrderDate=DateTime.Parse("2021-09-28")},
 new Orders{StadiumID=4,CustomerID=2,OrderDate=DateTime.Parse("2021-09-28")},
 new Orders{StadiumID=6,CustomerID=1,OrderDate=DateTime.Parse("2021-10-28")},
 };
                foreach (Orders e in orders)
                {
                    context.Orders.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
