﻿
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Autor>().Property(x => x.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Autor>().Property(x => x.FechaNacimiento).HasColumnType("date");

            modelBuilder.Entity<Comentario>().Property(x => x.Contenido).HasMaxLength(500);

            modelBuilder.Entity<Genero>().Property(x => x.Nombre).HasMaxLength(150);

            modelBuilder.Entity<Libro>().Property(x => x.Titulo).HasMaxLength(200);
            modelBuilder.Entity<Libro>().Property(x => x.FechaLanzamiento).HasColumnType("date");

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
