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
    public class RestauranteDALImpl : IRestauranteDAL
    {

        proyectoCarnesDonFernandoContext context;

        public RestauranteDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public RestauranteDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(Restaurante entity)
        {
            try
            {
                using (UnidadDeTrabajo<Restaurante> unidad = new UnidadDeTrabajo<Restaurante>(context))
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


        public void AddRange(IEnumerable<Restaurante> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurante> Find(Expression<Func<Restaurante, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Restaurante Get(int id)
        {
            Restaurante restaurante;
            using (UnidadDeTrabajo<Restaurante> unidad = new UnidadDeTrabajo<Restaurante>(context))
            {

                restaurante = unidad.genericDAL.Get(id);
            }
            return restaurante;

        }



        public IEnumerable<Restaurante> GetAll()
        {
            try
            {
                IEnumerable<Restaurante> restaurantes;
                using (UnidadDeTrabajo<Restaurante> unidad = new UnidadDeTrabajo<Restaurante>(context))
                {
                    restaurantes = unidad.genericDAL.GetAll();
                }
                return restaurantes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Restaurante entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Restaurante> unidad = new UnidadDeTrabajo<Restaurante>(context))
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

       

        public void RemoveRange(IEnumerable<Restaurante> entities)
        {
            throw new NotImplementedException();
        }

    

        public Restaurante SingleOrDefault(Expression<Func<Restaurante, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Restaurante entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Restaurante> unidad = new UnidadDeTrabajo<Restaurante>(context))
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
