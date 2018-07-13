using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command.Handler;
using ModernStore.Domain.Command.Inputs;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly ClienteComandoHandler _handler;

        public ClienteController(IUow uow,ClienteComandoHandler handler)
            :base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/clientes")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegistraClienteComando comando)
        {
            var result = _handler.Handle(comando);
            return await Response(result, _handler.Notifications);
        }
    }
}
