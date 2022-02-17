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

    public class AlterarEmail : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlterarEmail(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPatch("{id}")]

        public async Task<ActionResult<Produto>> PatchProduto(int id, string email)
        {
            var produto = await _context.Produtos.FindAsync(id);


            if (produto == null)
            {
                return NotFound();
            }

            produto.Email = email;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}