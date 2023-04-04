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
    public class CarritoItemDALImpl : ICarritoItemDAL
    {

        pruebasCarnesDonFernandoContext context;

        public CarritoItemDALImpl()
        {
            context = new pruebasCarnesDonFernandoContext ();

        }


        public CarritoItemDALImpl(pruebasCarnesDonFernandoContext _Context)
        {
            context = _Context;

        }
        public bool Add(CarritoItem entity)
        {
            try
            {
                using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(context))
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

        public void AddRange(IEnumerable<CarritoItem> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarritoItem> Find(Expression<Func<CarritoItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public CarritoItem Get(int id)
        {
            CarritoItem carritoItem;
            using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(context))
            {

                carritoItem = unidad.genericDAL.Get(id);
            }
            return carritoItem;

        }

        public IEnumerable<CarritoItem> GetAll()
        {
            try
            {
                IEnumerable<CarritoItem> carritoItems;
                using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(context))
                {
                    carritoItems = unidad.genericDAL.GetAll();
                }
                return carritoItems;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(CarritoItem entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(context))
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

        public void RemoveRange(IEnumerable<CarritoItem> entities)
        {
            throw new NotImplementedException();
        }

        public CarritoItem SingleOrDefault(Expression<Func<CarritoItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(CarritoItem entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<CarritoItem> unidad = new UnidadDeTrabajo<CarritoItem>(context))
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
