using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContextCore : DbContext
    {
        private string _connectionString = "Server=sqlserver,1433;Database=Practico1;User Id=sa;Password=Abc*123!;Encrypt=False;";
        //"Data Source=SC-LENOVO\\SQLEXPRES;Initial Catalog=DOTNETPRACTICO1;Integrated Security=True

        public DBContextCore() { }

        public DBContextCore(DbContextOptions<DBContextCore> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
           optionsBuilder.UseSqlServer(_connectionString);
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Vehiculos> Vehiculos { get; set; }

        public static void UpdateDatabase()
        {
            using (var context = new DBContextCore())
            {
                context.Database.Migrate();
            }

        }
    }
}
