using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RestauranteHelper
    {
        private ServiceRepository ServiceRepository;


        public RestauranteHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<RestauranteViewModel> GetAll()
        {
            List<RestauranteViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Restaurante/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<RestauranteViewModel>>(content);



            return lista;
        }

        public RestauranteViewModel Get(int id)
        {
            RestauranteViewModel Restaurante;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Restaurante/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);



            return Restaurante;
        }


        public RestauranteViewModel Create(RestauranteViewModel restaurante)
        {


            RestauranteViewModel Restaurante;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Restaurante/", restaurante);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);



            return Restaurante;
        }




        public RestauranteViewModel Edit(RestauranteViewModel restaurante)
        {


            RestauranteViewModel Restaurante;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Restaurante/", restaurante);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);



            return Restaurante;
        }



        public RestauranteViewModel Delete(int id)
        {


            RestauranteViewModel Restaurante;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Restaurante/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Restaurante = JsonConvert.DeserializeObject<RestauranteViewModel>(content);



            return Restaurante;
        }

    }




}