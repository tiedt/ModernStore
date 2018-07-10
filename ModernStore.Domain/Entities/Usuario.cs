using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
    public class Usuario
    {
        public long  Id { get; private set; }
        public string  Login { get; private set; }
        public string  Senha{ get; private set; }
        public bool Ativo { get; private set; }
        

        public Usuario(long id, string login, string senha)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Ativo = false;
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

    }
}
