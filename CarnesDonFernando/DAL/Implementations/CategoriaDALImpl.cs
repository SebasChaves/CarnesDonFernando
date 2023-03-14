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
    public class CategoriaDALImpl : ICategoriaDAL
    {

        proyectoCarnesDonFernandoContext context;

        public CategoriaDALImpl ()
        {
            context = new proyectoCarnesDonFernandoContext ();

        }


        public CategoriaDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;

        }
        public bool Add(Categoria entity)
        {
            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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

        public void AddRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Find(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Categoria Get(int id)
        {
            Categoria category;
            using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
            {

                category = unidad.genericDAL.Get(id);
            }
            return category;

        }

        public IEnumerable<Categoria> GetAll()
        {
            try
            {
                IEnumerable<Categoria> categories;
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
                {
                    categories = unidad.genericDAL.GetAll();
                }
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Categoria entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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

        public void RemoveRange(IEnumerable<Categoria> entities)
        {
            throw new NotImplementedException();
        }

        public Categoria SingleOrDefault(Expression<Func<Categoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Categoria> unidad = new UnidadDeTrabajo<Categoria>(context))
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
