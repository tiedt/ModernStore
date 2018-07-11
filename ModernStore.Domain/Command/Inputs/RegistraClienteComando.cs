using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Inputs
{
   public class RegistraClienteComando : ICommand
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
