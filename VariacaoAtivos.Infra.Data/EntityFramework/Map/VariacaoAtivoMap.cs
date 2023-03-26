using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VariacaoAtivos.Domain.Entity;

namespace VariacaoAtivos.Infra.Data.EntityFramework.Map
{
    public class VariacaoAtivoMap : MapBase<VariacaoAtivo>
    {
        public override void Configure(EntityTypeBuilder<VariacaoAtivo> builder)
        {
            base.Configure(builder);

            builder.ToTable("VARIACAOATIVO");
            builder.HasKey(P => P.Id);
            builder.Property(p => p.Id)
                .HasColumnType("int")
                .HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Ativo).HasColumnName("ATIVO").HasColumnType("nvarchar(10)");
            builder.Property(p => p.Dia).HasColumnName("DIA").HasColumnType("int");
            builder.Property(p => p.Data).HasColumnName("DATA").HasColumnType("datetime2");
            builder.Property(p => p.Valor).HasColumnName("VALOR").HasColumnType("decimal(4,2)");
            builder.Property(p => p.VariacaoDia).HasColumnName("VARIACAODIA").HasColumnType("decimal(4,2)");
            builder.Property(p => p.VariacaoPrimeiraData).HasColumnName("VARIACAOPRIMEIRADATA").HasColumnType("decimal(4,2)");
        }
    }
}