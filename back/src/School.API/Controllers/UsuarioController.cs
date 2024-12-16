using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.API.Data;
using School.API.models;
using System.Collections.Generic;
using System.Linq;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
    
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }
        

        // Método para listar todos os usuários
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Usuarios); 
        }

        // Método para listar um usuário por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        // Método para adicionar um novo usuário
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuário inválido.");
            }

            _context.Usuarios.Add(usuario);
            
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // Método para alterar os dados de um usuário
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Sobrenome = usuario.Sobrenome;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.DataNascimento = usuario.DataNascimento;
            usuarioExistente.Escolaridade = usuario.Escolaridade;

            _context.SaveChanges();


            return NoContent();
        }

        // Método para excluir um usuário
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }

        // Endpoint para simular um erro
        [HttpGet("error")]
        public IActionResult Error()
        {
            return StatusCode(500, "Erro interno simulado!");
        }
    }
}
