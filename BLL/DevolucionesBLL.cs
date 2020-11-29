using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Entidades;
using Proyecto_Final.DAL;

namespace Proyecto_Final.BLL
{
   public class DevolucionesBLL
    {
        public static bool Guardar(Devoluciones Devoluciones)
        {
            if (!Existe(Devoluciones.DevolucionId))
                return Insetar(Devoluciones);
            else
            {
                return Modificar(Devoluciones);
            }

        }
        private static bool Insetar(Devoluciones Devoluciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //agregar la entidad que decea insertar en el contexto
                contexto.Devoluciones.Add(Devoluciones);
                paso = contexto.SaveChanges() > 0;

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
        private static bool Modificar(Devoluciones Devoluciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //marcar la intidad como modificada para que el contexto sepa proceder
                contexto.Entry(Devoluciones).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var Devoluciones = contexto.Devoluciones.Find(id);
                if (Devoluciones != null)
                {
                    contexto.Devoluciones.Remove(Devoluciones); //remover la entidad
                    paso = contexto.SaveChanges() > 0;

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

        public static Devoluciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Devoluciones Devoluciones;
            try
            {
                Devoluciones = contexto.Devoluciones.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Devoluciones;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Devoluciones.Any(e => e.DevolucionId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return encontrado;



        }
        public static List<Devoluciones> GetList(Expression<Func<Devoluciones, bool>> criterio)
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido por parametro.
                lista = contexto.Devoluciones.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return lista;
        }

        public static List<Devoluciones> GetDevoluciones()
        {
            List<Devoluciones> lista = new List<Devoluciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Devoluciones.ToList();

            }
            catch (Exception)
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
