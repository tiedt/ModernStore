using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Results
{
   public class RegistraClienteComandoResult : ICommandResult
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public RegistraClienteComandoResult()
        {

        }
        public RegistraClienteComandoResult(long id, string nome)
        {
            Id = id;
            Nome = nome; 
        }
    }
}
