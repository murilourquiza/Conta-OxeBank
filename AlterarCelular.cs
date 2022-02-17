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

    public class AlterarCelular : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlterarCelular(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPatch("{id}")]

        public async Task<ActionResult<Produto>> PatchProduto(int id, ulong celular)
        {
            var produto = await _context.Produtos.FindAsync(id);


            if (produto == null)
            {
                return NotFound();
            }

            produto.Celular = celular;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}