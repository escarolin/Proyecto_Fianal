using System;
using System.Linq;
using System.Linq.Expressions;
using Proyecto_Final.DAL;
using System.Collections.Generic;
using Proyecto_Final.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Proyecto_Final.BLL{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if(!Existe(productos.ProductoId))
            return Insertar(productos);
            else{
                return Modificar(productos);
            }

         
         }
       
       private static bool Insertar (Productos productos)
       {
           bool paso=false;
           Contexto contexto =new Contexto();
           try{
                //agregar la entidad que decea insertar en el contexto
                 contexto.Productos.Add(productos);
                 paso=contexto.SaveChanges() >0;

           }
              
             catch (Exception)
             {
                 throw;
            
             }
             finally
             {
                 contexto.Dispose();
             }
             return paso;
            
       }

       private static bool Modificar (Productos productos)
       {
           bool paso=false;
           Contexto contexto = new Contexto();
            try 
             {
                 //marcar la intidad como modificada para que el contexto sepa proceder
                 contexto.Productos.Add(productos);
                 paso=contexto.SaveChanges()>0;

             }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 contexto.Dispose();
             }
             return paso;
         }

         public static bool Eliminar (int id)
         {
             bool paso = false;
             Contexto contexto =new Contexto();
             try{
                 //buscar la entida que se desea eliminar
                 var productos=contexto.Productos.Find(id);
                if (productos!=null)
                {
                    contexto.Productos.Remove(productos); //remover la entidad
                    paso=contexto.SaveChanges()>0;
                }

               }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 contexto.Dispose();
             }
             return paso;

         }
  

         public static Productos Buscar(int id){
             Contexto contexto= new Contexto();
             Productos productos;
             try 
             {
                 productos=contexto.Productos.Find(id);
             }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 contexto.Dispose();
             }
             return productos;

            }

          public static bool Existe(int id){
              Contexto contexto =new Contexto();
              bool encontrado =false;
              try{
                  encontrado=contexto.Productos.Any(e=> e.ProductoId==id);
              }
              catch(Exception)
   {
       throw;
   }
    finally
    {
        contexto.Dispose();

    }
 return encontrado;

    }
       
      public static List<Productos> GetList(Expression<Func<Productos,bool>> criterio){
          List<Productos>lista=new List<Productos>();
          Contexto contexto = new Contexto();
          try
          {
              //Obtener la lista y filtrarla segun el criterio recibido por parametro.
               lista =contexto.Productos.Where(criterio).ToList();

          }
          catch(Exception)
   {
       throw;
   }
    finally
    {
        contexto.Dispose();

    }
 return lista;
          
              

          
      }


          }

         }