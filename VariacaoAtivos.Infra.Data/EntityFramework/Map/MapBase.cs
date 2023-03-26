using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariacaoAtivos.Domain.Entity;

namespace VariacaoAtivos.Infra.Data.EntityFramework.Map
{
    public abstract class MapBase<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
