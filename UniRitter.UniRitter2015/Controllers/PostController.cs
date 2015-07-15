using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using UniRitter.UniRitter2015.Models;
using UniRitter.UniRitter2015.Services;

namespace UniRitter.UniRitter2015.Controllers
{
    public class PostController : ApiController
    {
        private readonly IRepository<PostModel> _repo;

        public PostController(IRepository<PostModel> repo)
        {
            this._repo = repo;
        }

        // GET: api/Post
        public IHttpActionResult Get()
        {
            return Json(_repo.GetAll());
        }

        // GET: api/Post/5
        public IHttpActionResult Get(Guid id)
        {
            var data = _repo.GetById(id);
            if (data != null)
            {
                return Json(data);
            } else {
                return NotFound();
            }
        }

        // POST: api/Post
        public IHttpActionResult Post([FromBody]PostModel model)
        {
            if (ModelState.IsValid)
            {
                var data = _repo.Add(model);
                return Json(data);
            } else {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Post/5
        public IHttpActionResult Put(Guid id, [FromBody]PostModel model)
        {
            var data = _repo.Update(id, model);
            return Json(model);
        }

        // DELETE: api/Post/5
        public IHttpActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
