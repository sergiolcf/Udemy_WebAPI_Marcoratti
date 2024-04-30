using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }



        public IQueryable<Produto> GetProdutos()
        {
            return _context.Produtos;
        }

        public Produto GetProdutoById(int id)
        {
            var produto = _context.Produtos?.Find(id);
            if (produto is null)
                throw new InvalidOperationException($"Produto com id {id} não encontrado.");

            return produto;
        }

        public Produto Create(Produto produto)
        {
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool UpdateProduto(Produto produto)
        {
            if (produto is null)
                throw new InvalidOperationException("Produto é null");

            if (_context.Produtos != null && _context.Produtos.Any(p => p.Id == produto.Id))
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProduto(int id)
        {
            var produto = _context.Produtos?.Find(id);

            if (produto is not null)
            {
                _context.Remove(produto);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}