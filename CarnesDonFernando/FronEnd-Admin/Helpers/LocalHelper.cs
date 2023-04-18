using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class LocalHelper
    {
        private ServiceRepository ServiceRepository;


        public LocalHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<LocalViewModel> GetAll()
        {
            List<LocalViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Local/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<LocalViewModel>>(content);



            return lista;
        }

        public LocalViewModel Get(int id)
        {
            LocalViewModel Local;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Local/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Local = JsonConvert.DeserializeObject<LocalViewModel>(content);



            return Local;
        }


        public LocalViewModel Create(LocalViewModel local)
        {


            LocalViewModel Local;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Local/", local);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Local = JsonConvert.DeserializeObject<LocalViewModel>(content);



            return Local;
        }




        public LocalViewModel Edit(LocalViewModel local)
        {


            LocalViewModel Local;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Local/", local);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Local = JsonConvert.DeserializeObject<LocalViewModel>(content);



            return Local;
        }



        public LocalViewModel Delete(int id)
        {


            LocalViewModel Local;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Local/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Local = JsonConvert.DeserializeObject<LocalViewModel>(content);



            return Local;
        }

    }




}