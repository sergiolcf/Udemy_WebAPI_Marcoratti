using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
      private readonly IUnitOfWork _unitOfWork;

        public ProdutosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("produtosPorCategoria/{id:int}")]
        public ActionResult<IEnumerable<Produto>> GetPorCategoria(int id)
        {
            var produtos = _unitOfWork.ProdutoRepository.GetProdutosPorCategoria(id);

            if (produtos is null)
                return NotFound($"Produtos com a categiraID = {id} não foram encontrados");

            return Ok(produtos);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _unitOfWork.ProdutoRepository.GetAll();

            if (produtos is null)
                return NotFound();

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _unitOfWork.ProdutoRepository.Get(p => p.Id == id);

            if (produto is null)
                return NotFound("Produto não encontrado");

            return Ok(produto);
        }

  
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {

            if(id != produto.Id)
                return BadRequest();

            var produtos = _unitOfWork.ProdutoRepository.Get(p => p.Id == produto.Id);
            _unitOfWork.Commit();

            if (produtos is null)
                return NotFound($"Produto com o id {produto.Id} não foi encontrado");

            _unitOfWork.ProdutoRepository.Update(produto);
            return Ok(produto);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(Produto produto)
        {
            var produtoToDelete = _unitOfWork.ProdutoRepository.Get(p => p.Id == produto.Id);

            if (produtoToDelete is null)
                return StatusCode(500, $"Falha ao deletar o produto de id = {produto.Id}");

            _unitOfWork.ProdutoRepository.Delete(produtoToDelete);
            _unitOfWork.Commit();

            return Ok("Produto Deletado");
        }
    }
}