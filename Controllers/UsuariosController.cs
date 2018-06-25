using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCore_EFCoreInMemory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore_EFCoreInMemory.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private readonly ApiContext _context;

        public UsuariosController(ApiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {

            var usuarios = await _context.Usuarios
                                 .Include(u => u.Posts)
                                 .ToArrayAsync();

            var resposta = usuarios.Select(u => new
            {
                nome = u.Nome,
                email = u.Email,
                posts = u.Posts.Select(p => p.Conteudo)
            });

            return Ok(resposta);
        }
    }
}