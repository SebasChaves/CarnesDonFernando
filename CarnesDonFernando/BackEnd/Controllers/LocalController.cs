﻿using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILogger<LocalController> logger;
        private ILocalDAL localDAL;


        public LocalController(ILogger<LocalController> logger)
        {
            localDAL = new LocalDALImpl(new pruebasCarnesDonFernandoContext());
            this.logger = logger;
        }

        private LocalModel? Convertir(Local model)
        {
            if(model is null)
            {
                return null;
            }
            else
            {
                return new LocalModel
                {
                    IdLocal = model.IdLocal,
                    Horario = model.Horario,
                    NombreLocal = model.NombreLocal,
                    Ubicacion = model.Ubicacion,
                    UrlImg = model.UrlImg,
                    Telefono = model.Telefono
                };
            }
        }
        private Local? Convertir(LocalModel model)
        {
            if (model is null)
            {
                return null;
            }
            else
            {
                return new Local
                {
                    IdLocal = model.IdLocal,
                    Horario = model.Horario,
                    NombreLocal = model.NombreLocal,
                    Ubicacion = model.Ubicacion,
                    UrlImg = model.UrlImg,
                    Telefono = model.Telefono
                };
            }
        }

        // GET: api/<LocalController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Local> locales = localDAL.GetAll();

            List<LocalModel> lista = new List<LocalModel>();

            foreach (var local in locales)
            {
                lista.Add(Convertir(local)

                    );
            }
            return new JsonResult(lista);
        }

        // GET api/<LocalController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Local local;
            local = localDAL.Get(id);

            return new JsonResult(Convertir(local));
        }

        // POST api/<LocalController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Post([FromBody] LocalModel local)
        {
            localDAL.Add(Convertir(local));
            return new JsonResult(local);
        }

        // PUT api/<LocalController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public JsonResult Put([FromBody] LocalModel local)
        {
            localDAL.Update(Convertir(local));
            return new JsonResult(local);
        }

        // DELETE api/<LocalController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Local local = new Local { IdLocal = id };
            localDAL.Remove(local);

            return new JsonResult(Convertir(local));
        }
    }
}
