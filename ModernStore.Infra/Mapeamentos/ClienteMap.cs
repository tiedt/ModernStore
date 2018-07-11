using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Mapeamentos
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");
            HasKey(x => x.Id);
            Property(x => x.DataNascimento);
            Property(x => x.Documento.Numero).IsRequired().HasMaxLength(11).IsFixedLength(); 
            Property(x => x.Email.Endereco).IsRequired().HasMaxLength(160);
            Property(x => x.Nome.PrimeiroNome).IsRequired().HasMaxLength(60);
            Property(x => x.Nome.SegundoNome).IsRequired().HasMaxLength(60);
            HasRequired(x => x.Usuario);
        }
    }
}
