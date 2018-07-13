using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModernStore.Domain.Command.Inputs
{
    public class AutenticaUsuarioComando : ICommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
