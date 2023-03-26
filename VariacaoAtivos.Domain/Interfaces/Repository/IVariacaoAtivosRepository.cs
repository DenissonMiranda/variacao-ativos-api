using VariacaoAtivos.Domain.Entity;

namespace VariacaoAtivos.Domain.Interfaces.Repository
{
    public interface IVariacaoAtivosRepository : IRepositoryBase<VariacaoAtivo>
    {
        Task<IEnumerable<VariacaoAtivo>> ConsultarVariacaoAtivos(string ativo);
    }
}
