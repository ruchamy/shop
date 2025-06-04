using Games.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Data
{
    public class DataContext : DbContext
    {

        IConfiguration configuration;

        public DataContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //conection string מקובץ חיצוני
            optionsBuilder.UseSqlServer(configuration["DbConectionString"]);
        }
        //public DataContext()
        //{
        //    Categories = new List<Category>()
        //    {  
        //        new Category(){Id = 0, Name = "ggg"},
        //        new Category(){Id = 1, Name = "hhh"},
        //        new Category(){Id = 2, Name = "fff"}
        //    };
        //}
    }
}
