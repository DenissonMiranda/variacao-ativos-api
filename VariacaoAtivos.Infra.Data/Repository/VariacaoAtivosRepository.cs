using Microsoft.EntityFrameworkCore;
using VariacaoAtivos.Domain.Entity;
using VariacaoAtivos.Domain.Interfaces.Repository;
using VariacaoAtivos.Infra.Data.Contexts;

namespace VariacaoAtivos.Infra.Data.Repository
{
    public class VariacaoAtivosRepository : RepositoryBase<VariacaoAtivo>, IVariacaoAtivosRepository
    {
        public VariacaoAtivosRepository(Context context) 
            : base(context)
        {
        }

        public async Task<IEnumerable<VariacaoAtivo>> ConsultarVariacaoAtivos(string ativo)
        {
            return await _context.VariacaoAtivo.Where(w => w.Ativo == ativo).OrderBy(o => o.Data).ToListAsync();
        }
    }
}
