using Banco.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;



namespace Banco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class _Login : ControllerBase
    {
        private readonly AppDbContext _context;

        public _Login(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Produto>> GetProduto(int id, ulong cpf, string senha)
        {
            var produto = await _context.Produtos.FindAsync(id);


            if (produto == null)
            {
                return NotFound();
            }

            if(produto.Cpf == cpf)
            {
                if(String.Compare(produto.Senha, senha) == 0)
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}