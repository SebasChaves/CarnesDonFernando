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
    public class IngredienteDALImpl : IIngredienteDAL
    {
        
        proyectoCarnesDonFernandoContext context;

        public IngredienteDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public IngredienteDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(Ingrediente entity)
        {
            try
            {
                using (UnidadDeTrabajo<Ingrediente> unidad = new UnidadDeTrabajo<Ingrediente>(context))
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

  
        public void AddRange(IEnumerable<Ingrediente> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ingrediente Get(int id)
        {
            Ingrediente ingrediente;
            using (UnidadDeTrabajo<Ingrediente> unidad = new UnidadDeTrabajo<Ingrediente>(context))
            {

                ingrediente = unidad.genericDAL.Get(id);
            }
            return ingrediente;

        }

       

        public IEnumerable<Ingrediente> GetAll()
        {
            try
            {
                IEnumerable<Ingrediente> ingrediente;
                using (UnidadDeTrabajo<Ingrediente> unidad = new UnidadDeTrabajo<Ingrediente>(context))
                {
                    ingrediente = unidad.genericDAL.GetAll();
                }
                return ingrediente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Ingrediente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Ingrediente> unidad = new UnidadDeTrabajo<Ingrediente>(context))
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

        public void RemoveRange(IEnumerable<Ingrediente> entities)
        {
            throw new NotImplementedException();
        }

        public Ingrediente SingleOrDefault(Expression<Func<Ingrediente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ingrediente entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Ingrediente> unidad = new UnidadDeTrabajo<Ingrediente>(context))
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
