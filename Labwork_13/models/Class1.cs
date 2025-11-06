using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Labwork_13.models
{
    public class equipment
    {
        public int id { get; set; }
        public int count { get; set; }
        public string type { get; set; }
    }

    public class accidents
    {
        public int id { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string type { get; set; }
    }

    

    public class employees
    {
        public int id { get; set; }
        public string name { get; set; }
        public string post { get; set; }
    }

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }


        public DbSet<employees> employees => Set<employees>();
        public DbSet<accidents> accidents => Set<accidents>();
        public DbSet<equipment> accessibleEquipment => Set<equipment>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            object value = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Lab_12_MES_BD;Username=postgres;Password=;");
        }

    }
}
