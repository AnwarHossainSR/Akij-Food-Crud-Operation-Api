using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akij_Food_Crud_Operation_Api.Models;

namespace Akij_Food_Crud_Operation_Api.data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<ColdDrink> ColdDrinks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ColdDrink>().HasData(
                new ColdDrink
                {
                    ColdDrinksId = 1,
                    ColdDrinksName = "Clemon",
                    Quantity = 450,
                    UnitPrice = 20
                },
                new ColdDrink
                {
                    ColdDrinksId = 2,
                    ColdDrinksName = "Frutika",
                    Quantity = 500,
                    UnitPrice = 25
                },
                new ColdDrink
                {
                    ColdDrinksId = 3,
                    ColdDrinksName = "Speed",
                    Quantity = 600,
                    UnitPrice = 30
                }
            );
        }

        public DbSet<Akij_Food_Crud_Operation_Api.Models.ColdDrinkDTO> ColdDrinkDTO { get; set; }

    }
}
