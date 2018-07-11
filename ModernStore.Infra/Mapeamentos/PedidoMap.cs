using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapeamentos
{
   public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");
            HasKey(x => x.Id);
            Property(x => x.DataCriacao);
            Property(x => x.FreteGratis).HasColumnType("money");
            Property(x => x.Desconto).HasColumnType("money");
            Property(x => x.NumeroPedido).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(x => x.Status);

             HasMany(x => x.Items);
             HasRequired(x => x.Cliente);
        }
    }
}
