﻿using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        public readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            try
            {
                //throw  new DataMisalignedException();
              return _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao conectar no Banco de Dados");
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get() => _context.Categorias.AsNoTracking().ToList();

        [HttpGet("{id:int}", Name ="ObterCategoria")]
        public ActionResult<Categoria> Get(int id) {


            //throw new Exception("Exceção ao retonar o produto pelo ID");

            string[] teste = null;

            if(teste.Length > 0)
            {

            }

            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (categoria is null)
                return NotFound("Categoria não encontrada...");

            return Ok(categoria);
        
        }


        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges(); 

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPost("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if(categoria is null)
                return NotFound("Categoria não encontrada...");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges(); 

            return Ok(categoria);
        }

    }
}
