using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultar.Models;
using Consultar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace Consultar.Controllers
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


            if (usuario.Login.Length < 8 || usuario.Senha.Length < 8)
            {
                return BadRequest("Login e senha devem conter no mínimo 8 caracteres");
            }
            else
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return Created("", usuario);
            }

        }

        //GET api/usuario/listar
        [HttpGet]
        [Route("listar")]

        public IActionResult List() => Ok(_context.Usuarios.ToList());

        [HttpGet]
        [Route("getbyid/{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

        //DELETE: api/usuario/delete/
        [HttpDelete]
        [Route("delete/{name}")]
        public IActionResult Delete([FromRoute] string name)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault
            (
                usuario => usuario.Nome == name
            );
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok(_context.Usuarios.ToList());
        }

        //PUT: api/usuario/update
        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }

        //GET: api/usuario/login
        [HttpGet]
        [Route("login")]

        public IActionResult Login(string login, string senha)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(
                u => u.Login == login && u.Senha == senha
            );

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(usuario);
            }
        }

    }
}
