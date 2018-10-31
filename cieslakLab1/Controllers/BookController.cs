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
    public class BookController : ControllerBase
    {
        public readonly IRepository<Book> _rep;

        public BookController(IRepository<Book> rep)
        {
            _rep = rep;
        }

        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            var book = _rep.FindById(id);
            if (book == null)
                return NotFound(id);
            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                _rep.Insert(book);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetBook", new { id = book.ID }, book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                _rep.Update(book);
                _rep.UnitOfWork.SaveChanges();
                return Ok(book);
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
