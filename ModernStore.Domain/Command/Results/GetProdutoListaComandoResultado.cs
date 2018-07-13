using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Results
{
   public class GetProdutoListaComandoResultado : ICommandResult
    {
        public long ID { get; set; }
        public string NomeProduto { get; set; }
        public string  Imagem { get; set; }
        public string Preco { get; set; }
    }
}
