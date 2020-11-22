using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;
using System;


namespace Proyecto_Final.DAL{

    
         public class Contexto : DbContext
             {
                public DbSet <Usuarios> Usuarios { get; set; }
                         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    {
                         optionsBuilder.UseSqlite(@"Data Source = Data\Proyecto.db");
                    }
                protected override void   OnModelCreating (ModelBuilder modelBuilder){
                     modelBuilder.Entity<Usuarios>().HasData(new Usuarios
                    {
                 
                 UsuarioId=1, 
                 Nombres= "Escarolin",
                 Apellidos="Ventura Polanco",
                 Fecha= new DateTime(2020,11,22),
                  UsuarioN="Esca",
                  Clave="f76043a74ec33b6aefbb289050faf7aa8d482095477397e3e63345125d49f527" });

                }



    }
    
}

