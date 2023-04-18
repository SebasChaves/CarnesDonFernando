using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Helpers
{
    public class MensajesContactoHelper
    {
        private ServiceRepository ServiceRepository;


        public MensajesContactoHelper()
        {
            ServiceRepository= new ServiceRepository();
        }



        public List<MensajesContactoViewModel> GetAll()
        {
            List<MensajesContactoViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/MensajesContacto/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista= JsonConvert.DeserializeObject<List<MensajesContactoViewModel>>(content);



            return lista;
        }

        public MensajesContactoViewModel Get(int id)
        {
            MensajesContactoViewModel MensajesContacto;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/MensajesContacto/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MensajesContacto = JsonConvert.DeserializeObject<MensajesContactoViewModel>(content);



            return MensajesContacto;
        }


        public MensajesContactoViewModel Create(MensajesContactoViewModel mensajesContacto) {


            MensajesContactoViewModel MensajesContacto;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/MensajesContacto/", mensajesContacto);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MensajesContacto = JsonConvert.DeserializeObject<MensajesContactoViewModel>(content);



            return MensajesContacto;
        }




        public MensajesContactoViewModel Edit(MensajesContactoViewModel mensajesContacto)
        {


            MensajesContactoViewModel MensajesContacto;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/MensajesContacto/", mensajesContacto);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MensajesContacto = JsonConvert.DeserializeObject<MensajesContactoViewModel>(content);



            return MensajesContacto;
        }



        public MensajesContactoViewModel Delete(int id)
        {


            MensajesContactoViewModel MensajesContacto;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/MensajesContacto/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            MensajesContacto = JsonConvert.DeserializeObject<MensajesContactoViewModel>(content);



            return MensajesContacto;
        }

    } 




    }

