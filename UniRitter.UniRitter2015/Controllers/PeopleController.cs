using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniRitter.UniRitter2015.Models;
using UniRitter.UniRitter2015.Services;

namespace UniRitter.UniRitter2015.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IRepository<PersonModel> _repo;

        public PeopleController(IRepository<PersonModel> repo)
        {
            this._repo = repo;
        }

        // GET: api/Person
        public IHttpActionResult Get()
        {
            return Json(_repo.GetAll());
        }

        // GET: api/Person/5
        public IHttpActionResult Get(Guid id)
        {
            var data = _repo.GetById(id);
            if (data != null)
            {
                return Json(data);
            }

            return NotFound();
        }

        // POST: api/Person
        public IHttpActionResult Post([FromBody]PersonModel model)
        {
            if (ModelState.IsValid)
            {
                var data = _repo.Add(model);
                return Json(data);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT: api/Person/5
        public IHttpActionResult Put(Guid id, [FromBody]PersonModel model)
        {
            var data = _repo.Update(id, model);
            return Json(model);
        }

        // DELETE: api/Person/5
        public IHttpActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}