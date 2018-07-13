using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Command.Inputs;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Api.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _repositorio;
        public ProdutoController(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("v1/produtos")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_repositorio.Get());
        }
    }
}
