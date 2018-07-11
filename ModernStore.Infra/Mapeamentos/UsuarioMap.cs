using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapeamentos
{
   public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Login).IsRequired().HasMaxLength(20);
            Property(x => x.Senha).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Ativo);
        }
    }
}
