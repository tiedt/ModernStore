using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Endereco { get; private set; }
        protected Email() { }

        public Email(string endereco)
        {
            Endereco = endereco;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Endereco, "E-mail inválido");
        }
    }
}
