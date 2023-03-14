using DAL.Interfaces;
using Entities;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class MensajesContactoDALImpl : IDALMensajesContacto
    {

        proyectoCarnesDonFernandoContext context;

        public MensajesContactoDALImpl()
        {
            context = new proyectoCarnesDonFernandoContext();

        }


        public MensajesContactoDALImpl(proyectoCarnesDonFernandoContext _Context)
        {
            context = _Context;
        }

        public bool Add(MensajesContacto entity)
        {
            try
            {
                using (UnidadDeTrabajo<MensajesContacto> unidad = new UnidadDeTrabajo<MensajesContacto>(context))
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

  
        public void AddRange(IEnumerable<MensajesContacto> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MensajesContacto> Find(Expression<Func<MensajesContacto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public MensajesContacto Get(int id)
        {
            MensajesContacto mensajesContacto;
            using (UnidadDeTrabajo<MensajesContacto> unidad = new UnidadDeTrabajo<MensajesContacto>(context))
            {

                mensajesContacto = unidad.genericDAL.Get(id);
            }
            return mensajesContacto;

        }

       

        public IEnumerable<MensajesContacto> GetAll()
        {
            try
            {
                IEnumerable<MensajesContacto> mensajesContacto;
                using (UnidadDeTrabajo<MensajesContacto> unidad = new UnidadDeTrabajo<MensajesContacto>(context))
                {
                    mensajesContacto = unidad.genericDAL.GetAll();
                }
                return mensajesContacto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(MensajesContacto entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<MensajesContacto> unidad = new UnidadDeTrabajo<MensajesContacto>(context))
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

        public void RemoveRange(IEnumerable<MensajesContacto> entities)
        {
            throw new NotImplementedException();
        }

        public MensajesContacto SingleOrDefault(Expression<Func<MensajesContacto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(MensajesContacto entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<MensajesContacto> unidad = new UnidadDeTrabajo<MensajesContacto>(context))
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
