using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        protected Nome() { }

        public Nome(string primeiroNome, string segundoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;

            new ValidationContract<Nome>(this)
        .IsRequired(x => x.PrimeiroNome, "Nome é obrigatório")
        .HasMaxLenght(x => x.PrimeiroNome, 60)
        .HasMinLenght(x => x.PrimeiroNome, 3)
        .IsRequired(x => x.SegundoNome, "Sobrenome é obrigatório")
        .HasMaxLenght(x => x.SegundoNome, 60)
        .HasMinLenght(x => x.SegundoNome, 3);
        }
        public override string ToString()
        {
            return $"{PrimeiroNome} {SegundoNome}";
        }
    }
}
