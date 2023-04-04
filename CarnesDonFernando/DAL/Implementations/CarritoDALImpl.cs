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
    public class CarritoDALImpl : ICarritoDAL
    {

        pruebasCarnesDonFernandoContext context;

        public CarritoDALImpl()
        {
            context = new pruebasCarnesDonFernandoContext ();

        }


        public CarritoDALImpl(pruebasCarnesDonFernandoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Carrito entity)
        {
            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
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

        public void AddRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Carrito> Find(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Carrito Get(int id)
        {
            Carrito carrito;
            using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
            {

                carrito = unidad.genericDAL.Get(id);
            }
            return carrito;

        }

        public IEnumerable<Carrito> GetAll()
        {
            try
            {
                IEnumerable<Carrito> carritos;
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
                {
                    carritos = unidad.genericDAL.GetAll();
                }
                return carritos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Carrito entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
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

        public void RemoveRange(IEnumerable<Carrito> entities)
        {
            throw new NotImplementedException();
        }

        public CarritoItem SingleOrDefault(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Carrito entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Carrito> unidad = new UnidadDeTrabajo<Carrito>(context))
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

        Carrito IDALGenerico<Carrito>.SingleOrDefault(Expression<Func<Carrito, bool>> predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
