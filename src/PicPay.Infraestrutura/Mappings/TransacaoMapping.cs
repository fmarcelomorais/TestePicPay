using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPay.Domain.Models;

namespace PicPay.Infraestrutura.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.NumeroTransacao).HasColumnType("VARCHAR(32)");
            builder.Property(t => t.DataTransacao).HasDefaultValueSql("NEWDATE()");
            builder.Property(t => t.StatusTransacao).HasColumnType("BIT");
            builder.Property(t => t.ValorTransacao).HasPrecision(10,2);

            builder.HasMany(t => t.UsuariosTransacao).WithMany(u => u.Transacoes);
        }
    }
}
