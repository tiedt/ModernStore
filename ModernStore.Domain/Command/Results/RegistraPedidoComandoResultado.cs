using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Results
{
   public class RegistraPedidoComandoResultado : ICommandResult
    {
        public string Numero { get; set; }
        public RegistraPedidoComandoResultado()
        {

        }
        public RegistraPedidoComandoResultado(string numero)
        {
            Numero = numero;
        }
    }
}
