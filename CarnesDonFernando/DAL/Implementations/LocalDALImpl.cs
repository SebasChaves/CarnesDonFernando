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
    public class LocalDALImpl : ILocalDAL
    {

        proyectoCarnesDonFernandoContext context;

        public LocalDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public LocalDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(Local entity)
        {
            try
            {
                using (UnidadDeTrabajo<Local> unidad = new UnidadDeTrabajo<Local>(context))
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


        public void AddRange(IEnumerable<Local> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Local> Find(Expression<Func<Local, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Local Get(int id)
        {
            Local local;
            using (UnidadDeTrabajo<Local> unidad = new UnidadDeTrabajo<Local>(context))
            {

                local = unidad.genericDAL.Get(id);
            }
            return local;

        }



        public IEnumerable<Local> GetAll()
        {
            try
            {
                IEnumerable<Local> locales;
                using (UnidadDeTrabajo<Local> unidad = new UnidadDeTrabajo<Local>(context))
                {
                    locales = unidad.genericDAL.GetAll();
                }
                return locales;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Local entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Local> unidad = new UnidadDeTrabajo<Local>(context))
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

       

        public void RemoveRange(IEnumerable<Local> entities)
        {
            throw new NotImplementedException();
        }

    

        public Local SingleOrDefault(Expression<Func<Local, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Local entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Local> unidad = new UnidadDeTrabajo<Local>(context))
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
