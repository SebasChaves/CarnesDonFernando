using DAL.Interfaces;
using DAL.Implementations;
using Microsoft.AspNetCore.Mvc;
using Entities;
using BackEnd.Models;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private IProductoDAL productoDAL; 

        public ProductoController()
        {
            productoDAL =  new ProductoDALImpl(new Entities.proyectoCarnesDonFernandoContext());

        }

        private ProductoModel? Convertir(Producto model)
        {
                return new ProductoModel
                {
                    IdCategoria = model.IdCategoria,
                    IdProducto = model.IdProducto,
                    Nombre = model.Nombre,
                    Precio = model.Precio,
                    DescripcionProductoLarga = model.DescripcionProductoLarga,
                    DescripcionProductoCorta = model.DescripcionProductoCorta,
                    Cantidad = model.Cantidad,
                    UrlImg = model.UrlImg
                };
            
            
        }
        private Producto? Convertir(ProductoModel model)
        {
            return new Producto
            {
                IdCategoria = model.IdCategoria,
                IdProducto = model.IdProducto,
                Nombre = model.Nombre,
                Precio = model.Precio,
                DescripcionProductoLarga = model.DescripcionProductoLarga,
                DescripcionProductoCorta = model.DescripcionProductoCorta,
                Cantidad = model.Cantidad,
                UrlImg = model.UrlImg
            };
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Producto> productos = productoDAL.GetAll();
            List<ProductoModel> lista = new List<ProductoModel>();

            foreach (var producto in productos)
            {
                lista.Add(Convertir(producto)

                    );
            }

            return new JsonResult(lista);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Producto producto;
            producto = productoDAL.Get(id);

            return new JsonResult(Convertir(producto));
        }

        // POST api/<ProductoController>
        [HttpPost]
        public JsonResult Post([FromBody] ProductoModel producto)
        {
            productoDAL.Add(Convertir(producto));
            return new JsonResult(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ProductoModel producto)
        {
            productoDAL.Update(Convertir(producto));
            return new JsonResult(producto);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Producto producto = new Producto { IdProducto = id };
            productoDAL.Remove(producto);

            return new JsonResult(productoDAL.Remove(producto));
            

        }
    }
}
