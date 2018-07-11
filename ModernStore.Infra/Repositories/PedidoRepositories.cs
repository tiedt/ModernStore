using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Repositories
{
   public class PedidoRepositories : IPedidoRepositorio
    {
        private readonly ModernStoreDataContext _context;

        public PedidoRepositories(ModernStoreDataContext context)
        {
            _context = context;
        }

        public void Salvar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido); 
        }
    }
}
