using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Inputs
{
   public class UpdateClienteComando : ICommand
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public DateTime DataAniversario { get; set; }
    }
}
