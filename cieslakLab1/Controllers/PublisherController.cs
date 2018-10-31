using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cieslakLab1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cieslakLab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public readonly IRepository<Publisher> _rep;

        public PublisherController(IRepository<Publisher> rep)
        {
            _rep = rep;
        }

        // GET: api/Publisher
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Publisher/5
        [HttpGet("{id}", Name = "GetPublisher")]
        public IActionResult Get(int id)
        {
            var publisher = _rep.FindById(id);
            if (publisher == null)
                return NotFound(id);
            return Ok(publisher);
        }

        // POST: api/Publisher
        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            try
            {
                _rep.Insert(publisher);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetPublisher", new { id = publisher.ID }, publisher);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Publisher/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher publisher)
        {
            try
            {
                _rep.Update(publisher);
                _rep.UnitOfWork.SaveChanges();
                return Ok(publisher);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _rep.Delete(id);
                _rep.UnitOfWork.SaveChanges();
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
