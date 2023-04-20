using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{

    public class FacturaHelper
    {
        private ServiceRepository ServiceRepository;


        public FacturaHelper()
        {
            ServiceRepository = new ServiceRepository();
        }
        public FacturaHelper(string token)
        {
            ServiceRepository = new ServiceRepository(token);
        }


        public List<FacturaViewModel> GetAll()
        {
            List<FacturaViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Factura/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<FacturaViewModel>>(content);



            return lista;
        }

        public FacturaViewModel Get(int id)
        {
            FacturaViewModel carrito;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Factura/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            carrito = JsonConvert.DeserializeObject<FacturaViewModel>(content);



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


        public FacturaViewModel Create(FacturaViewModel categoria)
        {


            FacturaViewModel carrito;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Factura/", categoria);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            carrito = JsonConvert.DeserializeObject<FacturaViewModel>(content);



            return carrito;
        }




        public FacturaViewModel Edit(FacturaViewModel categoria)
        {


            FacturaViewModel carrito;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Factura/", categoria);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            carrito = JsonConvert.DeserializeObject<FacturaViewModel>(content);



            return carrito;
        }



        public FacturaViewModel Delete(int id)
        {


            FacturaViewModel carrito;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Factura/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            carrito = JsonConvert.DeserializeObject<FacturaViewModel>(content);



            return carrito;
        }

    }




}

