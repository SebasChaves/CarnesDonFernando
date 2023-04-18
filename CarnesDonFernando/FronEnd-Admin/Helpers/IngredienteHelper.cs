using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class IngredienteHelper
    {
        private ServiceRepository ServiceRepository;


        public IngredienteHelper()
        {
            ServiceRepository = new ServiceRepository();
        }

        public List<IngredienteViewModel> GetAll()
        {
            List<IngredienteViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Ingrediente/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<IngredienteViewModel>>(content);



            return lista;
        }

        public IngredienteViewModel Get(int id)
        {
            IngredienteViewModel Ingrediente;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Ingrediente/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Ingrediente = JsonConvert.DeserializeObject<IngredienteViewModel>(content);



            return Ingrediente;
        }


        public IngredienteViewModel Create(IngredienteViewModel ingrediente)
        {


            IngredienteViewModel Ingrediente;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Ingrediente/", ingrediente);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Ingrediente = JsonConvert.DeserializeObject<IngredienteViewModel>(content);



            return Ingrediente;
        }




        public IngredienteViewModel Edit(IngredienteViewModel ingrediente)
        {


            IngredienteViewModel Ingrediente;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Ingrediente/", ingrediente);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Ingrediente = JsonConvert.DeserializeObject<IngredienteViewModel>(content);



            return Ingrediente;
        }



        public IngredienteViewModel Delete(int id)
        {


            IngredienteViewModel Ingrediente;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Ingrediente/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Ingrediente = JsonConvert.DeserializeObject<IngredienteViewModel>(content);



            return Ingrediente;
        }

    }




}
