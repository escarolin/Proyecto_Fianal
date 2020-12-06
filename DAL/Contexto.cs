using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;
using System;


namespace Proyecto_Final.DAL
{


    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Devoluciones> Devoluciones { get; set; }

        public DbSet<EntradaProductos> EntradaProductos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Proyecto.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Administrador",
                Apellidos = "del Programa",
                Fecha = new DateTime(2020, 11, 22),
                UsuarioN = "admin",
                Clave = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5"
            });

            modelBuilder.Entity<Marcas>().HasData(new Marcas
            { MarcaId = 1, NombreMarca = " Rotoplas" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            { MarcaId = 2, NombreMarca = "Truper" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            { MarcaId = 3, NombreMarca = " IUSA" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            { MarcaId = 4, NombreMarca = "Austromex" });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            { MarcaId = 5, NombreMarca = "Nacobre" });



        }
    }
}