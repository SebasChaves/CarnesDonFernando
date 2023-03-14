using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
   
        public class CategoriaHelper
        {
            private ServiceRepository ServiceRepository;


            public CategoriaHelper()
            {
                ServiceRepository = new ServiceRepository();
            }



            public List<CategoriaViewModel> GetAll()
            {
                List<CategoriaViewModel> lista;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Categoria/");
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(content);



                return lista;
            }

            public CategoriaViewModel Get(int id)
            {
            CategoriaViewModel Categoria;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Categoria/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            Categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);



                return Categoria;
            }


            public CategoriaViewModel Create(CategoriaViewModel categoria)
            {


            CategoriaViewModel Categoria;


                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Categoria/", categoria);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);



                return Categoria;
            }




            public CategoriaViewModel Edit(CategoriaViewModel categoria)
            {


            CategoriaViewModel Categoria;


                HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Categoria/", categoria);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);



                return Categoria;
            }



            public CategoriaViewModel Delete(int id)
            {


            CategoriaViewModel Categoria;


                HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Categoria/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                     Categoria = JsonConvert.DeserializeObject<CategoriaViewModel>(content);



                return Categoria;
            }

        }




    }

