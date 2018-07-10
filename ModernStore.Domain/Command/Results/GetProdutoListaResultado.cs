using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Command.Results
{
    public class GetProdutoListaResultado : ICommandResult
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}
