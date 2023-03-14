using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class DetalleOrdenHelper
    {
        
       private ServiceRepository ServiceRepository;


        public DetalleOrdenHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<DetalleOrdenViewModel> GetAll()
        {
            List<DetalleOrdenViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/DetalleOrden/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<DetalleOrdenViewModel>>(content);



            return lista;
        }

        public DetalleOrdenViewModel Get(int id)
        {
            DetalleOrdenViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/DetalleOrden/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<DetalleOrdenViewModel>(content);



            return DetalleOrden;
        }


        public DetalleOrdenViewModel Create(DetalleOrdenViewModel detalleOrden)
        {


            DetalleOrdenViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/DetalleOrden/", detalleOrden);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<DetalleOrdenViewModel>(content);



            return DetalleOrden;
        }




        public DetalleOrdenViewModel Edit(DetalleOrdenViewModel detalleOrden)
        {


            DetalleOrdenViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/DetalleOrden/", detalleOrden);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<DetalleOrdenViewModel>(content);



            return DetalleOrden;
        }



        public DetalleOrdenViewModel Delete(int id)
        {


            DetalleOrdenViewModel DetalleOrden;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/DetalleOrden/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            DetalleOrden = JsonConvert.DeserializeObject<DetalleOrdenViewModel>(content);



            return DetalleOrden;
        }

    }

}

