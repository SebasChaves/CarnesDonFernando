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
    public class DetalleOrdenDALImpl : IDALDetalleOrden
    {
        
        proyectoCarnesDonFernandoContext context;

        public DetalleOrdenDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public DetalleOrdenDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(DetalleOrden entity)
        {
            try
            {
                using (UnidadDeTrabajo<DetalleOrden> unidad = new UnidadDeTrabajo<DetalleOrden>(context))
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

  
        public void AddRange(IEnumerable<DetalleOrden> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DetalleOrden> Find(Expression<Func<DetalleOrden, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DetalleOrden Get(int id)
        {
            DetalleOrden detalleOrden;
            using (UnidadDeTrabajo<DetalleOrden> unidad = new UnidadDeTrabajo<DetalleOrden>(context))
            {

                detalleOrden = unidad.genericDAL.Get(id);
            }
            return detalleOrden;

        }

       

        public IEnumerable<DetalleOrden> GetAll()
        {
            try
            {
                IEnumerable<DetalleOrden> detalleorden;
                using (UnidadDeTrabajo<DetalleOrden> unidad = new UnidadDeTrabajo<DetalleOrden>(context))
                {
                    detalleorden = unidad.genericDAL.GetAll();
                }
                return detalleorden;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(DetalleOrden entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<DetalleOrden> unidad = new UnidadDeTrabajo<DetalleOrden>(context))
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

        public void RemoveRange(IEnumerable<DetalleOrden> entities)
        {
            throw new NotImplementedException();
        }

        public DetalleOrden SingleOrDefault(Expression<Func<DetalleOrden, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(DetalleOrden entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<DetalleOrden> unidad = new UnidadDeTrabajo<DetalleOrden>(context))
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
