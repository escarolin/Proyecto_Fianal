using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;


namespace Proyecto_Final.DAL{

    
    public class Contexto : DbContext
    {
 public DbSet <Usuarios> Usuarios { get; set; }
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Proyecto.db");
        }


    }
    
}

