

using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class SecurityHelper
    {
        private ServiceRepository ServiceRepository;


        public SecurityHelper()
        {
            ServiceRepository = new ServiceRepository();
        }




        public TokenModel Login(LoginModel usuario)
        {
            try
            {
                TokenModel TokenModel;


                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Authenticate/login" ,usuario);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                TokenModel = JsonConvert.DeserializeObject<TokenModel>(content);



                return TokenModel;



            }
            catch (Exception)
            {

                throw;
            }
        } 

        public IdUsuario getIdUsuario(LoginModel usuario)
        {
            try {
                IdUsuario idUsuario;

                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Authenticate/getUsuario", usuario);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                idUsuario = JsonConvert.DeserializeObject<IdUsuario>(content);

                return idUsuario;
            } catch (Exception) { 
                
                throw; 
            }

            
        }
        public ResponseModel Registrar(RegisterModel usuario)
        {
            try
            {
                ResponseModel response;

                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Authenticate/register", usuario);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<ResponseModel>(content);

                return response;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public ResponseModel RegistrarAdmin(RegisterModel usuario)
        {
            try
            {
                ResponseModel response;

                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Authenticate/register-admin", usuario);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<ResponseModel>(content);

                return response;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public ResponseModel CambioContrasenia(ContraseniaModel usuario)
        {
            try
            {
                ResponseModel response;

                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Authenticate/putContrasenia", usuario);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<ResponseModel>(content);

                return response;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
