using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Cliente : Entity
    {
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public Usuario Usuario { get; private set; }
        

        public Cliente(string primeiroNome, string segundoNome,DateTime dataNascimento,
             string senha, string email,Usuario usuario)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;
            DataNascimento = dataNascimento;
            Email = email;
            Usuario = usuario;

            //validaçãoes 
            
        }
        public override string ToString()
        {
            return $"{PrimeiroNome} {SegundoNome}";
        }
    }
}
