using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UsuarioHelper
    {
        private ServiceRepository ServiceRepository;


        public UsuarioHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<UsuarioViewModel> GetAll()
        {
            List<UsuarioViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Usuario/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);



            return lista;
        }

        public UsuarioViewModel Get(int id)
        {
            UsuarioViewModel Usuario;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Usuario/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



            return Usuario;
        }


        public UsuarioViewModel Create(UsuarioViewModel usuario)
        {


            UsuarioViewModel Usuario;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Usuario/", usuario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



            return Usuario;
        }




        public UsuarioViewModel Edit(UsuarioViewModel usuario)
        {


            UsuarioViewModel Usuario;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Usuario/", usuario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



            return Usuario;
        }



        public UsuarioViewModel Delete(int id)
        {


            UsuarioViewModel Usuario;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Usuario/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);



            return Usuario;
        }

    }




}