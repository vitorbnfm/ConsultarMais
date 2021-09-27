using System;
using System.Collections.Generic;
using System.Linq;
using Consultar.Data;
using Consultar.Models;
using Microsoft.AspNetCore.Mvc;


namespace Consultar.Controllers
{
    [ApiController]
    [Route("api/consulta")]
    public class ConsultaController : ControllerBase
    {
        private readonly DataContext _context;

        //Construtor
        public ConsultaController(DataContext context) => _context = context;

        //POST: api/consulta/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return Created("", consulta);
        }

        //GET: api/consulta/list
        [HttpGet]
        [Route("list")]
        public IActionResult List() => Ok(_context.Consultas.ToList());

        //GET: api/consulta/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar pela chave primária
            Consulta consulta = _context.Consultas.Find(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        //DELETE: api/consulta/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] DateTime data)
        {
            //Buscar consulta pela data
            Consulta consulta = _context.Consultas.FirstOrDefault
            (
                consulta => consulta.DataConsulta == data
            );
            if (consulta == null)
            {
                return NotFound();
            }
            _context.Consultas.Remove(consulta);
            _context.SaveChanges();
            return Ok(_context.Consultas.ToList());
        }

        //PUT: api/consulta/create
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            _context.SaveChanges();
            return Ok(consulta);
        }


    }
}