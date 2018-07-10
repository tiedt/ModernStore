using FluentValidator;
using ModernStore.Domain.Command;
using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Handler
{
    public class PedidoComandoHandler : Notifiable,
          ICommandHandler<RegistraPedidoComando>
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IPedidoRepositorio  _pedidoRepositorio;

        public PedidoComandoHandler(IClienteRepositorio clienteRepositorio, IProdutoRepositorio produtoRepositorio, IPedidoRepositorio pedidoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public ICommandResult Handle(RegistraPedidoComando command)
        {
            // Instancia o cliente (Lendo do repositorio)
            var cliente = _clienteRepositorio.Get(command.Cliente);

            // Gera um novo pedido
            var pedido = new Pedido(cliente, command.EntregaGratuita, command.Desconto);

            // Adiciona os itens no pedido
            foreach (var item in command.Items)
            {

                var produto = _produtoRepositorio.Get(item.Produto);
                pedido.AddItem(new ItemPedido(produto, item.Quantidade));
            }

            // Adiciona as notificações do Pedido no Handler
            AddNotifications(pedido.Notifications);

            // Persiste no banco
            if (IsValid())
                _pedidoRepositorio.Salvar(pedido);

            return new RegistraPedidoComandoResultado(pedido.NumeroPedido);
        }
    }
}