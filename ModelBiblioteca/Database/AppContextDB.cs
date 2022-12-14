using Microsoft.EntityFrameworkCore;
using ModelBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelBiblioteca.Database
{
    public class AppContextDB: DbContext
    {
       
        public DbSet<Autor> Autors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<InstanceBook> InstanceBooks { get; set; } = null!;
        public DbSet<StateBook> StateBooks { get; set; } = null!;
        public DbSet<TrafficBook> TrafficBooks { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<WordKey> WordKeys { get; set; } = null!;



        public AppContextDB() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateBook>().HasIndex(u => new { u.BookId, u.TrafficDir }).IsUnique();
            modelBuilder.Entity<WordKey>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<InstanceBook>().HasOne(u => u.StateBook)
                .WithOne(u => u.InstanseBook)
                .HasForeignKey<InstanceBook>(u => u.Id);
            modelBuilder.Entity<InstanceBook>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<StateBook>().Property(u => u.Id).ValueGeneratedOnAdd();
            //      modelBuilder.Entity<Category>()
            //.HasOne<Category>(d => d.Categor)
            //.WithMany(u=>u.Categories)
            //.HasForeignKey(u =>u.CategorId);
            // modelBuilder.Entity<Category>().HasKey(u => u.Id);
            //modelBuilder.Entity<Category>().Property(u => u.Id).ValueGeneratedOnAdd();

        }

    }
}
