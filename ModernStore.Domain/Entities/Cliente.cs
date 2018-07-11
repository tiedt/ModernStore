using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Cliente : Entity
    {
        public Nome Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Usuario Usuario { get; private set; }

        protected Cliente() { }

        public Cliente(Nome nome, Email email, Documento documento, Usuario usuario)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
            Usuario = usuario;

            AddNotifications(nome.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(documento.Notifications);
        }

        public void Update(Nome nome, DateTime dataNascimento)
        {
            AddNotifications(nome.Notifications);

            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
