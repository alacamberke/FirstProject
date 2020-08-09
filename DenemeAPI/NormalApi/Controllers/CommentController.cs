using Dal.Abstract;
using Dal.Concrete;
using Dtos;
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
    public class CommentController : ApiController
    {
        private IAppRepository _appService;
        public CommentController()
        {
            _appService = new AppRepository(new Dal.Context());
        }

        [HttpGet]
        [Route("api/Comment/getcommentbyhaber/{id}")]
        public IHttpActionResult GetCommentByHaber([FromUri]int id)
        {
            var haber = _appService.GetHaber(id);
            if(haber == null)
            {
                return NotFound();
            }
            var comments = _appService.GetCommentByHaber(id);
            if(comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpGet]
        [Route("api/Comment/getall")]
        public IHttpActionResult GetAllComments()
        {
            var comments = _appService.GetAllComment();
            
            if(comments == null)
            {
                return NotFound();
            }

            return Ok(comments);
        }

        [HttpPost]
        [Route("api/Comment/add")]
        public IHttpActionResult AddComment([FromBody]AddCommentDTO comment)
        {
            if(comment == null || ModelState.IsValid == false)
            {
                return BadRequest();
            }
            _appService.AddComment(comment);
            return Created("","Successfully Created!");
        }

        [HttpGet]
        [Route("api/Comment/delete")]
        public IHttpActionResult DeleteComment([FromUri]int id)
        {
            _appService.DeleteComment(id);
            return Ok("Successfully deleted.");
        }
    }
}
