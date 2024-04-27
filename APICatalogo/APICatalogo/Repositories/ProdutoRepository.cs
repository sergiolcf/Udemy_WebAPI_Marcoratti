using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Produto Create(Produto produto)
        {
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            var produtos = _context.Produtos?.ToList();
            if (produtos is null)
                throw new ArgumentNullException();

            return produtos;
        }

        public Produto GetProdutoById(int id)
        {
            var produto = _context.Produtos?.Find(id);
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

            return produto;
        }

        public bool UpdateProduto(Produto produto)
        {
            if (produto is null)
                throw new ArgumentNullException(nameof(produto));

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
