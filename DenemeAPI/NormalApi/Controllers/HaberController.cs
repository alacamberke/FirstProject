using Dal.Abstract;
using Dal.Concrete;
using Dtos;
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
    public class HaberController : ApiController
    {
        private IAppRepository _appService;
        public HaberController()
        {
            _appService = new AppRepository(new Dal.Context());
        }

        [Route("api/Haber/getall")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var habers = _appService.GetAllHaber();

            if(habers.Count == 0)
            {
                return NotFound();
            }

            return Ok(habers);
        }

        [Route("api/Haber/get/{id}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            var haber = _appService.GetHaber(id);

            if(haber == null)
            {
                return NotFound();
            }

            return Ok(haber);
        }

        [Route("api/Haber/add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]AddHaberDTO haber)
        {
            if (ModelState.IsValid && haber != null)
            {
                _appService.AddHaber(haber);
                return Created("","Creating succesfully!");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Haber/update")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]HaberDTO newhaber)
        {
            var haber = _appService.GetHaber(id);
            if(haber == null)
            {
                return NotFound();
            }
            else if (ModelState.IsValid && newhaber != null)
            {
                _appService.UpdateHaber(id, newhaber);
                return Ok();
            }
            return null;
        }
    }
}
