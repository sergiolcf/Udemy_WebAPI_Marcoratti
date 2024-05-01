﻿namespace APICatalogo.Repositories
{
    public interface IUnitOfWork
    {
        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        void Commit();
    }
}
