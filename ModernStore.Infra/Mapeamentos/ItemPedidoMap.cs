using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapeamentos
{
   public class ItemPedidoMap : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoMap()
        {
            ToTable("ItemPedido");
            HasKey(x => x.Id);
            Property(x => x.Preco).HasColumnType("money");
            Property(x => x.Quantidade);
            HasRequired(x => x.Produto);
        }
    }
}
