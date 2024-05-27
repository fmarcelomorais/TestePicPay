using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPay.Domain.Models;

namespace PicPay.Infraestrutura.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FullName).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Documento).HasMaxLength(14).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Senha).HasMaxLength(200).IsRequired();
            builder.Property(c => c.TipoUsuario).IsRequired();

            builder.HasOne(c => c.Conta).WithOne(c => c.Usuario).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.Transacoes).WithOne(t => t.UsuarioEnvia).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
