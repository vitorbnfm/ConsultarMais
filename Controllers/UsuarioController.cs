using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultar.Models;
using Consultar.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Consultar.Services;

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

         //POST api/usuario/create
         [HttpPost]
         [Route("create")]

         public IActionResult Create([FromBody] Usuario usuario)
         {
             var login = _context.Usuarios.FirstOrDefault(
                 u => u.Login == usuario.Login
             ); // se o usuário não existir, essa variavel será null

             if (login != null)
             {
                 return BadRequest(new { message = "O Login digitado já existe." });
             }

             if (usuario.Login.Length < 8 || usuario.Senha.Length < 8)
             {
                 return BadRequest("Login e senha devem conter no mínimo 8 caracteres");
             }

             if (usuario.Tipo == null)
             {
                 usuario.Tipo = "User";
             }
             _context.Usuarios.Add(usuario);
             _context.SaveChanges();
             usuario.Senha = "";
             return Created("", usuario);
         }

         //GET api/usuario/listar
         [HttpGet]
         [Route("list")]
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

         //POST: api/usuario/login
         [HttpPost]
         [Route("login")]

         public IActionResult Login([FromBody] Usuario usuario)
         {
             usuario = _context.Usuarios.FirstOrDefault(
                 u => u.Login == usuario.Login && u.Senha == usuario.Senha
             );

             if (usuario == null) // se não encontrar um usuário com o login e a senha retorna notfound
             {
                 return NotFound(new { message = "Usuário ou senha inválidos" });
             }

             usuario.Token = TokenService.CriarToken(usuario);
             usuario.Senha = "";
             return Ok(usuario);
         }
    }
}
