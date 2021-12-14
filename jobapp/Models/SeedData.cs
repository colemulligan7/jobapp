using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using jobapp.Data;
using System;
using System.Linq;

namespace jobapp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new jobappContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<jobappContext>>()))
            {
                
                // Look for any movies.
                if (context.Key.Any())
                {
                    return;   // DB has been seeded
                }

                context.Key.AddRange(
                    new Key
                    {
                        Name = "Item A",
                        Desc = "This is Item A",
                        Price = 7.99M
                    },

                    new Key
                    {
                        Name = "Item B",
                        Desc = "This is Item B",
                        Price = 1.25M
                    },

                    new Key
                    {
                        Name = "Item C",
                        Desc = "This is Item C",
                        Price = 5.00M
                    },

                    new Key
                    {
                        Name = "Item D",
                        Desc = "This is Item D",
                        Price = 10.99M
                    }
                );
                context.Tech.AddRange(
                    new Tech
                    {
                        first_name = "John",
                        last_name = "Doe",
                        Vehicle = 1,
                        
                    },

                    new Tech
                    {
                        first_name = "Cole",
                        last_name = "Mulligan",
                        Vehicle = 2,

                    },
                    new Tech
                    {
                        first_name = "Leroy",
                        last_name = "Jenkins",
                        Vehicle = 3,

                    }
                );
                context.Vehicle.AddRange(
                    new Vehicle
                    {
                        make = "Toyota",
                        model = "Camry",
                        year = "2020",
                        vin = "5462318"
                    },
                    new Vehicle
                    {
                        make = "Toyota",
                        model = "Carolla",
                        year = "2021",
                        vin = "64784135"
                    },
                    new Vehicle
                    {
                        make = "Toyota",
                        model = "Highlander",
                        year = "2019",
                        vin = "987421564"
                    }
                );
                context.SaveChanges();
               
            }
             
        }
    }
}