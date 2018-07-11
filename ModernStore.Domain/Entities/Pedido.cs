using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Pedido : Entity
    {
        private readonly IList<ItemPedido> _items;
        public Cliente Cliente { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string  NumeroPedido { get; private set; }
        public EPedidoStatus Status{ get; private set; }
        public ICollection<ItemPedido> Items => _items.ToArray();
        public decimal FreteGratis { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total => SubTotal() + FreteGratis - Desconto;
        protected Pedido() { }


        public Pedido(Cliente cliente,decimal freteGratis,decimal desconto)
        {
            Cliente = cliente;
            DataCriacao = DateTime.Now;
            NumeroPedido = Guid.NewGuid().ToString().Substring(0,8).ToUpper();
            Status = EPedidoStatus.Criado;
            FreteGratis = freteGratis;
            Desconto = desconto;
            _items = new List<ItemPedido>();
        }
        public void AddItem(ItemPedido item)
        {
               if(item.IsValid())
                _items.Add(item);
        }
    }
}
