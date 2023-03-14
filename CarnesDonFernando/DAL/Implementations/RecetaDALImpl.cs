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
    public class RecetaDALImpl : IRecetaDAL
    {
        
        proyectoCarnesDonFernandoContext context;

        public RecetaDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public RecetaDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(Receta entity)
        {
            try
            {
                using (UnidadDeTrabajo<Receta> unidad = new UnidadDeTrabajo<Receta>(context))
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

  
        public void AddRange(IEnumerable<Receta> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Receta> Find(Expression<Func<Receta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Receta Get(int id)
        {
            Receta receta;
            using (UnidadDeTrabajo<Receta> unidad = new UnidadDeTrabajo<Receta>(context))
            {

                receta = unidad.genericDAL.Get(id);
            }
            return receta;

        }

       

        public IEnumerable<Receta> GetAll()
        {
            try
            {
                IEnumerable<Receta> receta;
                using (UnidadDeTrabajo<Receta> unidad = new UnidadDeTrabajo<Receta>(context))
                {
                    receta = unidad.genericDAL.GetAll();
                }
                return receta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Receta entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Receta> unidad = new UnidadDeTrabajo<Receta>(context))
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

        public void RemoveRange(IEnumerable<Receta> entities)
        {
            throw new NotImplementedException();
        }

        public Receta SingleOrDefault(Expression<Func<Receta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Receta entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Receta> unidad = new UnidadDeTrabajo<Receta>(context))
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
