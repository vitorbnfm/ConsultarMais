using System;
using System.Collections.Generic;
using System.Linq;
using Consultar.Data;
using Consultar.Models;
using Microsoft.AspNetCore.Mvc;


namespace Consultar.Controllers
{
    [ApiController]
    [Route("api/paciente")]
    public class PacienteController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public PacienteController(DataContext context) => _context = context;

        //POST: api/paciente/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Created("", paciente);
        }

        //GET: api/paciente/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Pacientes.ToList());

        //GET: api/paciente/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um paciente pela chave primária
            Paciente paciente = _context.Pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        //DELETE: api/paciente/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            //Buscar um paciente pelo nome
            Paciente paciente = _context.Pacientes.FirstOrDefault
            (
                paciente => paciente.Nome == name
            );
            if (paciente == null)
            {
                return NotFound();
            }
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
            return Ok(_context.Pacientes.ToList());
        }

        //PUT: api/paciente/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }


    }
}