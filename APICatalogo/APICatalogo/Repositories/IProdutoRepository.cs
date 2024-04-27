using APICatalogo.Models;

namespace APICatalogo.Repositories
{
    public interface IProdutoRepository
    {
         Produto Create(Produto produto);
         IEnumerable<Produto> GetProdutos();
         Produto GetProdutoById(int id);
         bool UpdateProduto(Produto produto);
         bool DeleteProduto(int id);
    }
}
