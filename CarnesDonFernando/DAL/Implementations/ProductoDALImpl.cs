using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductoDALImpl : IProductoDAL
    {

        proyectoCarnesDonFernandoContext context;

        public ProductoDALImpl ()
        {
            context = new proyectoCarnesDonFernandoContext ();

        }

            
        public ProductoDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Producto entity)
        {
            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> Find(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Producto Get(int id)
        {
            Producto producto;
            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
            {

                producto = unidad.genericDAL.Get(id);
            }
            return producto;

        }

        public IEnumerable<Producto> GetAll()
        {
            try
            {
                IEnumerable<Producto> productos;
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
                {
                    productos = unidad.genericDAL.GetAll();
                }
                return productos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Producto entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public Producto SingleOrDefault(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Producto entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
}
