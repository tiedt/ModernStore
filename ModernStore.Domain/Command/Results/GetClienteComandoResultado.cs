using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Results
{
    public class GetClienteComandoResultado : ICommandResult
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

    }
}
