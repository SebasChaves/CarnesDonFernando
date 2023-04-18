using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class FacturaDetalleHelper
    {
        
       private ServiceRepository ServiceRepository;


        public FacturaDetalleHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<FacturaDetalleViewModel> GetAll()
        {
            List<FacturaDetalleViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/FacturaDetalle/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<FacturaDetalleViewModel>>(content);



            return lista;
        }

        public FacturaDetalleViewModel Get(int id)
        {
            FacturaDetalleViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/FacturaDetalle/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<FacturaDetalleViewModel>(content);



            return DetalleOrden;
        }


        public FacturaDetalleViewModel Create(FacturaDetalleViewModel detalleOrden)
        {


            FacturaDetalleViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/FacturaDetalle/", detalleOrden);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<FacturaDetalleViewModel>(content);



            return DetalleOrden;
        }




        public FacturaDetalleViewModel Edit(FacturaDetalleViewModel detalleOrden)
        {


            FacturaDetalleViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/FacturaDetalle/", detalleOrden);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<FacturaDetalleViewModel>(content);



            return DetalleOrden;
        }



        public FacturaDetalleViewModel Delete(int id)
        {


            FacturaDetalleViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/FacturaDetalle/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<FacturaDetalleViewModel>(content);



            return DetalleOrden;
        }

    }

}

