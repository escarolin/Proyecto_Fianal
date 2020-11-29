using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.DAL;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.BLL
{
   public class MarcasBLL
    {
        public static bool Guardar(Marcas marcas)
        {
            if (!Existe(marcas.MarcaId))
                return Insetar(marcas);
            else
            {
                return Modificar(marcas);
            }

        }
        private static bool Insetar(Marcas marcas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //agregar la entidad que decea insertar en el contexto
                contexto.Marcas.Add(marcas);
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
        private static bool Modificar(Marcas marcas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //marcar la intidad como modificada para que el contexto sepa proceder
                contexto.Entry(marcas).State = EntityState.Modified;
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
                var marcas = contexto.Marcas.Find(id);
                if (marcas != null)
                {
                    contexto.Marcas.Remove(marcas); //remover la entidad
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

        public static Marcas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Marcas marcas;
            try
            {
                marcas = contexto.Marcas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return marcas;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Marcas.Any(e => e.MarcaId == id);
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
        public static List<Marcas> GetList(Expression<Func<Marcas, bool>> criterio)
        {
            List<Marcas> lista = new List<Marcas>();
            Contexto contexto = new Contexto();
            try
            {
                //Obtener la lista y filtrarla segun el criterio recibido por parametro.
                lista = contexto.Marcas.Where(criterio).ToList();

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

        public static List<Marcas> GetSuplidores()
        {
            List<Marcas> lista = new List<Marcas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Marcas.ToList();

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
