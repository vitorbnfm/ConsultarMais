using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultar.Models;
using Consultar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Consultar_.Controllers
{
    [ApiController]
    [Route("api/usuario")]

    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        //POST api/usuario/criar
        [HttpPost]
        [Route("criar")]

        public IActionResult Create([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }

        //GET api/usuario/listar
        [HttpGet]
        [Route("listar")]

        public IActionResult List() => Ok(_context.Usuarios.ToList());
    }
}
