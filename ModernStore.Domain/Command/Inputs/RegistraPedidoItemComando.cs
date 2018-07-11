using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command
{
    public class RegistraPedidoItemComando : ICommand
    {
        public int Produto { get; set; }
        public int Quantidade { get; set; }
        public IEnumerable<RegistraPedidoItemComando> Items { get; set; }
    }
}
