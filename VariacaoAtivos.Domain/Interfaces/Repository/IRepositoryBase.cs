using VariacaoAtivos.Domain.Entity;

namespace VariacaoAtivos.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntidade>
        where TEntidade : EntityBase
    {
        Task<decimal> Incluir(TEntidade entidade);
        Task<TEntidade> IncluirComRetorno(TEntidade entidade);
        Task Excluir(TEntidade entidade);
        Task Alterar(TEntidade entidade);
        Task<TEntidade> SelecionarPorId(long id);
        Task<IEnumerable<TEntidade>> SelecionarTodos();
    }
}
