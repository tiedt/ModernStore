using FluentValidator;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
    public class Usuario : Entity
    {
        public string  Login { get; private set; }
        public string  Senha{ get; private set; }
        public bool Ativo { get; private set; }
        protected Usuario() { }


        public Usuario(string login, string senha,string confirmaSenha)
        {
            Login = login;
            Senha = EncryptPassword(senha);
            Ativo = false;

            new ValidationContract<Usuario>(this)
                .AreEquals(x => x.Senha, EncryptPassword(confirmaSenha), "As Senhas não são iguais");
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public bool Authenticate(string username, string password)
        {
            if (Login == username && Senha == EncryptPassword(password))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
