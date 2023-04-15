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
    public class FacturaDetalleDALImpl : IFacturaDetalleDAL
    {

        pruebasCarnesDonFernandoContext context;

        public FacturaDetalleDALImpl()
        {
            context = new pruebasCarnesDonFernandoContext ();

        }


        public FacturaDetalleDALImpl(pruebasCarnesDonFernandoContext _Context)
        {
            context = _Context;

        }
        public bool Add(FacturaDetalle entity)
        {
            try
            {
                using (UnidadDeTrabajo<FacturaDetalle> unidad = new UnidadDeTrabajo<FacturaDetalle>(context))
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

        public void AddRange(IEnumerable<FacturaDetalle> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FacturaDetalle> Find(Expression<Func<FacturaDetalle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public FacturaDetalle Get(int id)
        {
            FacturaDetalle carrito;
            using (UnidadDeTrabajo<FacturaDetalle> unidad = new UnidadDeTrabajo<FacturaDetalle>(context))
            {

                carrito = unidad.genericDAL.Get(id);
            }
            return carrito;

        }

        public IEnumerable<FacturaDetalle> GetAll()
        {
            try
            {
                IEnumerable<FacturaDetalle> carritos;
                using (UnidadDeTrabajo<FacturaDetalle> unidad = new UnidadDeTrabajo<FacturaDetalle>(context))
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

        public bool Remove(FacturaDetalle entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<FacturaDetalle> unidad = new UnidadDeTrabajo<FacturaDetalle>(context))
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

        public void RemoveRange(IEnumerable<FacturaDetalle> entities)
        {
            throw new NotImplementedException();
        }

        public FacturaDetalle SingleOrDefault(Expression<Func<FacturaDetalle, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(FacturaDetalle entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<FacturaDetalle> unidad = new UnidadDeTrabajo<FacturaDetalle>(context))
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
