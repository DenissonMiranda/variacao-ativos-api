using Microsoft.EntityFrameworkCore;
using VariacaoAtivos.Domain.Entity;

namespace VariacaoAtivos.Infra.Data.Contexts
{
    public partial class Context
    {
        public DbSet<VariacaoAtivo> VariacaoAtivo { get; set; }
    }
}
