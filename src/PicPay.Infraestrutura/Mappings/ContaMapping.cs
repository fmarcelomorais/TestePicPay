using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPay.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Infraestrutura.Mappings
{
    public class ContaMapping : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("Contas");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Saldo).HasPrecision(10, 2).IsRequired();

            builder.HasOne(c => c.Usuario).WithOne(c => c.Conta).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
