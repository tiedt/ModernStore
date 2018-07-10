using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command
{
    public class RegistraPedidoComando : ICommand
    {
        public long Cliente { get; set; }
        public decimal EntregaGratuita { get; set; }
        public decimal Desconto { get; set; }
        public IEnumerable<RegistraPedidoItemComando> Items { get; set; }

    }
}
