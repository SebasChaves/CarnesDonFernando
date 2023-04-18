using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RecetaHelper
    {
        private ServiceRepository ServiceRepository;


        public RecetaHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<RecetaViewModel> GetAll()
        {
            List<RecetaViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Receta/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<RecetaViewModel>>(content);



            return lista;
        }

        public RecetaViewModel Get(int id)
        {
            RecetaViewModel Receta;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Receta/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Receta = JsonConvert.DeserializeObject<RecetaViewModel>(content);



            return Receta;
        }


        public RecetaViewModel Create(RecetaViewModel receta)
        {


            RecetaViewModel Receta;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Receta/", receta);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Receta = JsonConvert.DeserializeObject<RecetaViewModel>(content);



            return Receta;
        }




        public RecetaViewModel Edit(RecetaViewModel receta)
        {


            RecetaViewModel Receta;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Receta/", receta);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Receta = JsonConvert.DeserializeObject<RecetaViewModel>(content);



            return Receta;
        }



        public RecetaViewModel Delete(int id)
        {


            RecetaViewModel Receta;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Receta/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Receta = JsonConvert.DeserializeObject<RecetaViewModel>(content);



            return Receta;
        }

    }




}