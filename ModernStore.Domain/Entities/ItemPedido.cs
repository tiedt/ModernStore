using FluentValidator;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class ItemPedido : Entity
    {
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Preco { get; private set; }

        public ItemPedido(Produto produto, int quantidade, decimal preco)
        {
            Produto = produto;
            Quantidade = quantidade;
            Preco = Produto.Preco;

            new ValidationContract<ItemPedido>(this)
              .IsGreaterThan(x => x.Quantidade, 1)
             .IsGreaterThan(x => x.Produto.Estoque, Quantidade + 1, $"Não temos tantos {produto.NomeProduto}(s) em estoque.");

        }
        public decimal Total() => Preco * Quantidade;
    }
}
