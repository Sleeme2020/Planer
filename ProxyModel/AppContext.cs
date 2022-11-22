using Microsoft.EntityFrameworkCore;
using Planer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel
{
    public class AppContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public DbSet<ChekPoint> ChekPoints { get; set; }
        public DbSet<AbstractTask> Tasks { get; set; }
        public DbSet<ChekPointDeal> ChekPointDeals { get; set; }
        public DbSet<ChekPointEvent> ChekPointEvents { get; set; }
        public DbSet<DealTask> DealTasks { get; set; }
        public DbSet<EventTask> EventTasks { get; set; }

        //public ApplicationContext() => Database.EnsureCreated();
        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Planer.db");
        }
    }
}
