using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command;
using ModernStore.Domain.Handler;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly PedidoComandoHandler _handler;
        public PedidoController(IUow uow,PedidoComandoHandler handler):base(uow)
        {
            _handler = handler;
        }
        [HttpPost]
        [Route("v1/pedidos")]
        public async Task<IActionResult> Post([FromBody]RegistraPedidoComando comando)
        {
            var result = _handler.Handle(comando);
            return await Response(result, _handler.Notifications);
        }
    }
}
