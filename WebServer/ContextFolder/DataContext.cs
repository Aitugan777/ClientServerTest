using Microsoft.EntityFrameworkCore;
using WebServer.Models;

namespace WebServer.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<AitukTask> Task { get; set; }
        public DbSet<AitukStatus> Status { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                DataBase=TasksDB;
                Trusted_Connection=True");
        }
    }
}
