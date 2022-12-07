using Microsoft.EntityFrameworkCore;
using ModelBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Database
{
    internal class AppContextDB: DbContext
    {
       
        public DbSet<Autor> Autors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<InstanceBook> InstanceBooks { get; set; } = null!;
        public DbSet<TrafficBook> TrafficBooks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WordKey> WordKeys { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

    }
}
