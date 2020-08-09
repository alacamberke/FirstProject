using Dal.Abstract;
using Dal.Concrete;
using Dtos.Kategori;
using Models;
using NormalApi.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NormalApi.Controllers
{
    [Logging]
    public class KategoriController : ApiController
    {
        private IAppRepository _appService;
        public KategoriController()
        {
            _appService = new AppRepository(new Dal.Context());
        }

        [Route("api/Kategori/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var kategoris = _appService.GetAllKategori();
            if (kategoris == null)
            {
                return NotFound();
            }
            return Ok(kategoris);
        }

        [Route("api/Kategori/get/{id}")]
        public IHttpActionResult Get([FromUri] int id)
        {
            var kategori = _appService.GetKategori(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return Ok(kategori);
        }

        [Route("api/Kategori/add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]AddKategoriDTO newkategori)
        {
            if (ModelState.IsValid && newkategori != null)
            {
                _appService.AddKategori(newkategori);
                return Created("",newkategori.KategoriName + " is created.");
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Kategori newkategori)
        {
            var kategori = _appService.GetKategori(id);
            if(kategori == null)
            {
                return NotFound();
            }
            else if(ModelState.IsValid && newkategori != null)
            {
                _appService.UpdateKategori(id, newkategori);
                return Ok(newkategori.KategoriName);
            }
            return null;
        }
    }
}
