using System;
using System.Collections.Generic;
using System.Linq;
using Consultar.Data;
using Consultar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Consultar.Controllers
{
    [ApiController]
    [Route("api/medico")]
    public class MedicoController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public MedicoController(DataContext context) => _context = context;

        //POST: api/medico/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
            return Created("", medico);
        }

        //GET: api/medico/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Medicos.ToList());

        //GET: api/medico/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um medico pela chave primária
            Medico medico = _context.Medicos.Find(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        //PUT: api/medico/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Medico medico)
        {
            _context.Medicos.Update(medico);
            _context.SaveChanges();
            return Ok(medico);
        }

        //GET: api/medico/delete
        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize]
        public IActionResult Delete([FromRoute] int id)
        {
            Medico medico = _context.Medicos.FirstOrDefault(c =>
                c.Id == id
            );
            if(medico == null) {
                return NotFound();
            }
            _context.Medicos.Remove(medico);
            _context.SaveChanges();
            return Ok(_context.Medicos.ToList());
        }


    }
}