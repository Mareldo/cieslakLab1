﻿using System;
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
    public class GenereController : ControllerBase
    {
        public readonly IRepository<Genere> _rep;

        public GenereController(IRepository<Genere> rep)
        {
            _rep = rep;
        }

        // GET: api/Genere
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rep.GetAll());
        }

        // GET: api/Genere/5
        [HttpGet("{id}", Name = "GetGenere")]
        public IActionResult Get(int id)
        {
            var genere = _rep.FindById(id);
            if (genere == null)
                return NotFound(id);
            return Ok(genere);
        }

        // POST: api/Genere
        [HttpPost]
        public IActionResult Post([FromBody] Genere genere)
        {
            try
            {
                _rep.Insert(genere);
                _rep.UnitOfWork.SaveChanges();
                return CreatedAtRoute("GetGenere", new { id = genere.ID }, genere);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Genere/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Genere genere)
        {
            try
            {
                _rep.Update(genere);
                _rep.UnitOfWork.SaveChanges();
                return Ok(genere);
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
