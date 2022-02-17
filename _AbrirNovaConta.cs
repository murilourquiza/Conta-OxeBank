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

    public class _AbrirNovaConta : ControllerBase
    {
        private readonly AppDbContext _context;

        public _AbrirNovaConta(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]

        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            int length = produto.Senha.Length;
           

            if (String.Compare(produto.Senha, produto.ConfirmarSenha) != 0)
            {
                return BadRequest();
            }
            else
            {
                if (length < 8)
                {
                    return BadRequest();
                }

                _context.Produtos.Add(produto);
                
                await _context.SaveChangesAsync();

                return NoContent();
            }

            
        }
    }
   }