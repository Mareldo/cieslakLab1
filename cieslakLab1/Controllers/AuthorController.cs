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
    public class AuthorController : ControllerBase
    {
        public readonly IRepository<Author> _rep;

        public AuthorController(IRepository<Author> rep)
        {
            _rep = rep;
        }

        // GET: api/Author
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            var author = _rep.FindById(id);
            if (author == null)
                return NotFound(id);
            return Ok(author);
        }

        // POST: api/Author
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            try
            {
                _rep.Insert(author);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetAuthor", new { id = author.ID }, author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                _rep.Update(author);
                _rep.UnitOfWork.SaveChanges();
                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
