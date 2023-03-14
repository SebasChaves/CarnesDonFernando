using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ProductoHelper
    {
        private ServiceRepository ServiceRepository;


        public ProductoHelper()
        {
            ServiceRepository = new ServiceRepository();
        }



        public List<ProductoViewModel> GetAll()
        {
            List<ProductoViewModel> lista;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Producto/");
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            lista = JsonConvert.DeserializeObject<List<ProductoViewModel>>(content);



            return lista;
        }

        public ProductoViewModel Get(int id)
        {
            ProductoViewModel Producto;


            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Producto/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);



            return Producto;
        }


        public ProductoViewModel Create(ProductoViewModel producto)
        {


            ProductoViewModel Producto;


            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Producto/", producto);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);



            return Producto;
        }




        public ProductoViewModel Edit(ProductoViewModel producto)
        {


            ProductoViewModel Producto;


            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Producto/", producto);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);



            return Producto;
        }



        public ProductoViewModel Delete(int id)
        {


            ProductoViewModel Producto;


            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Producto/" + id.ToString());
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            Producto = JsonConvert.DeserializeObject<ProductoViewModel>(content);



            return Producto;
        }

    }




}