using APICatalogo.Context;
using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaRepository _categoriasRepository;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriaRepository categoriaRepository, ILogger<CategoriasController> logger)
        {
            _categoriasRepository = categoriaRepository;
            _logger = logger;
        }


        //[HttpGet("produtos")]
        //public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        //{
        //    return _context.Categorias.Include(p => p.Produtos).AsNoTracking().ToList();
        //}

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _categoriasRepository.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _categoriasRepository.GetCategoria(id);
            if (categoria is null)
            {
                _logger.LogWarning($"Categoria com id= {id} não encontrada...");
                return NotFound($"Categoria com id= {id} não encontrada...");
            }
            return Ok(categoria);
        }


        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                _logger.LogWarning($"Dados Invalidos");
                return BadRequest("Dados Invalidos");
            }

            var categoriaCriada = _categoriasRepository.Create(categoria);
            return Ok(categoriaCriada);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if (id != categoria.Id || categoria is null)
            {
                _logger.LogWarning($"Dados Invalidos");
                return BadRequest("Dados Invalidos");
            }
            _categoriasRepository.Update(categoria);
            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _categoriasRepository.GetCategoria(id);

            if (categoria is null)
                return NotFound("Categoria não encontrada...");

            var categoriaExcluida = _categoriasRepository.Delete(id);

            return Ok(categoriaExcluida);
        }
    }
}
