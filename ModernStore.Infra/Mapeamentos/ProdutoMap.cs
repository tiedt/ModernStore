using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapeamentos
{
  public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Id);
            Property(x => x.Imagem).IsRequired().HasMaxLength(1024);
            Property(x => x.Preco);
            Property(x => x.Estoque);
            Property(x => x.NomeProduto).IsRequired().HasMaxLength(80);

        }
    }
}
