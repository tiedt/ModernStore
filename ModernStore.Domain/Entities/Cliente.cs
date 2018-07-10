using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Cliente : Entity
    {
        public Nome Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Documento CPF { get; private set; }
        public Email Email { get; private set; }
        public Usuario Usuario { get; private set; }
        

        public Cliente(Nome nome,DateTime dataNascimento,
             string senha, Email email,Usuario usuario,Documento documento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Usuario = usuario;
            CPF = documento;

            AddNotifications(nome.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(documento.Notifications);

        }
    }
}
