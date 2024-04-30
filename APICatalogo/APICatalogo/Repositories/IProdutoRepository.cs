using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> GetProdutos();
        Produto Create(Produto produto);
        Produto GetProdutoById(int id);
        bool UpdateProduto(Produto produto);
        bool DeleteProduto(int id);
    }
}
