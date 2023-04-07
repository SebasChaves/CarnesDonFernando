using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
   
        public class CarritoHelper
        {
            private ServiceRepository ServiceRepository;


            public CarritoHelper()
            {
                ServiceRepository = new ServiceRepository();
            }



            public List<CarritoViewModel> GetAll()
            {
                List<CarritoViewModel> lista;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Carrito/");
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<CarritoViewModel>>(content);



                return lista;
            }

            public CarritoViewModel Get(int id)
            {
            CarritoViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Carrito/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);



                return carrito;
            }

            public CarritoViewModel SetUsuario(string id)
            {
            CarritoViewModel carrito;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Carrito/GetCarritoUsuario/" + id);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);



                return carrito;
        }


            public CarritoViewModel Create(CarritoViewModel categoria)
            {


                    CarritoViewModel carrito;


                    HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Carrito/", categoria);
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);



                    return carrito;
             }




            public CarritoViewModel Edit(CarritoViewModel categoria)
            {


            CarritoViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Carrito/", categoria);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);



                return carrito;
            }



            public CarritoViewModel Delete(int id)
            {


            CarritoViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Carrito/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoViewModel>(content);



                return carrito;
            }

        }




    }

