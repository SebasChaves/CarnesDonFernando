using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
   
        public class CarritoItemsHelper
        {
            private ServiceRepository ServiceRepository;


            public CarritoItemsHelper()
            {
                ServiceRepository = new ServiceRepository();
            }



            public List<CarritoItemViewModel> GetAll()
            {
                List<CarritoItemViewModel> lista;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/CarritoItems/");
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<CarritoItemViewModel>>(content);



                return lista;
            }

            public List<CarritoItemViewModel> GetCarrito(int id)
            {
                List<CarritoItemViewModel> lista;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/CarritoItems/GetCarritoUsuario/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CarritoItemViewModel>>(content);



                return lista;
            }


        public CarritoItemViewModel Get(int id)
            {
            CarritoItemViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/CarritoItems/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoItemViewModel>(content);



                return carrito;
            }


            public CarritoItemViewModel Create(CarritoItemViewModel categoria)
            {


            CarritoItemViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/CarritoItems/", categoria);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoItemViewModel>(content);



                return carrito;
            }




            public CarritoItemViewModel Edit(CarritoItemViewModel categoria)
            {

            categoria.idUsuario = "";
            CarritoItemViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/CarritoItems/", categoria);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                carrito = JsonConvert.DeserializeObject<CarritoItemViewModel>(content);



                return carrito;
            }



            public CarritoItemViewModel Delete(int id)
            {


            CarritoItemViewModel carrito;


                HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/CarritoItems/" + id.ToString());
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            carrito = JsonConvert.DeserializeObject<CarritoItemViewModel>(content);



                return carrito;
            }

            public List<CarritoItemViewModel> DeleteRange()
            {
            List<CarritoItemViewModel> lista = new List<CarritoItemViewModel>();

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/CarritoItems/");
                var content = responseMessage.Content.ReadAsStringAsync();
           // lista = JsonConvert.DeserializeObject<List<CarritoItemViewModel>>(content);



            return lista;
            }

    }




    }

