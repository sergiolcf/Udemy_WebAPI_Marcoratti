using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repositoryProduto;

        public ProdutosController(IProdutoRepository repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _repositoryProduto.GetProdutos().ToList();

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _repositoryProduto.GetProdutoById(id);

            if (produto is null)
                return NotFound("Produto não encontrado");

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            var novoProduto = _repositoryProduto.Create(produto);

            return new CreatedAtRouteResult("ObterProduto",
                new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            var isUpdated = _repositoryProduto.UpdateProduto(produto);

            if (!isUpdated)
                return StatusCode(500, $"Falha ao atualizar o produto de id = {id}");

            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = _repositoryProduto.DeleteProduto(id);

            if (!isDeleted)
                return StatusCode(500, $"Falha ao deletar o produto de id = {id}");

            return Ok("Produto Deletado");
        }
    }
}