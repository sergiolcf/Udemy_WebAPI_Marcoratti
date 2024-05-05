using System.Linq.Expressions;

namespace ApiExecUm.Repositories.Interface
{  /// <summary>
   /// Define operações comuns (CRUD) que podem ser realizadas em um repositório dentro da entidade.
   /// </summary>
   /// <typeparam name="T">O tipo da entidade manipulada pelo repositório</typeparam>
    public interface IRepositoryServices<T> where T : class
    {
        /// <summary>
        /// Obtém todas as entidades do repositório
        /// </summary>
        /// <returns>Uma coleção de todas as entidades</returns>
        IEnumerable<T>? GetAll();
        /// <summary>
        /// Obtém uma entidade específica com base em um predicado de filtro.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>A entidade encontrada ou null se nenhuma entidade corresponder ao predicado</returns>
        T? Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Obter uma entidade Asyncrona
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>A entidade encontrar ou nulo se nenhuma entidade for correspondente ao predicado</returns>
        Task<T>? GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Cria o registro da entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> Retorna a entidade criada ou null se não conseguir fazer a criação</returns>
        T? Create(T entity);
        /// <summary>
        /// Atualiza o registro da entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna o registro atualizado ou null senão conseguir atualizar.</returns>
        T? Update(T entity);
        /// <summary>
        /// Deleta o registro da entidade
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Retorna o registro deletado (apenas para fins de visualização) ou null se não conseguir deletar</returns>
        T? Delete(T entity);
        /// <summary>
        /// Persiste no banco de dados
        /// </summary>
    }
}
