using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModernStore.Api.Seguranca;
using ModernStore.Domain.Command.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class AccountController : BaseController
    {
        private Cliente _cliente;
        private readonly IClienteRepositorio _repository;
        private readonly OpcaoToken _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AccountController(IOptions<OpcaoToken> jwtOptions, IUow uow, IClienteRepositorio repository) : base(uow)
        {
            _repository = repository;
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/autentica")]
        public async Task<IActionResult> Post([FromForm] AutenticaUsuarioComando command)
        {
            if (command == null)
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var identity = await GetClaims(command);
            if (identity == null)
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.Login),
                new Claim(JwtRegisteredClaimNames.NameId, command.Login),
                new Claim(JwtRegisteredClaimNames.Email, command.Login),
                new Claim(JwtRegisteredClaimNames.Sub, command.Login),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("ModernStore")
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims.AsEnumerable(),
                notBefore: _tokenOptions.NotBefore,
                expires: _tokenOptions.Expiration,
                signingCredentials: _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    id = _cliente.Id,
                    name = _cliente.Nome.ToString(),
                    email = _cliente.Email.Endereco,
                    username = _cliente.Usuario.Login
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        private static void ThrowIfInvalidOptions(OpcaoToken options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(OpcaoToken.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(OpcaoToken.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(OpcaoToken.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaims(AutenticaUsuarioComando command)
        {
            var customer = _repository.GetByUsername(command.Login);

            if (customer == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if (!customer.Usuario.Authenticate(command.Login, command.Senha))
                return Task.FromResult<ClaimsIdentity>(null);

            _cliente = customer;

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(customer.Usuario.Login, "Token"),
                new[] {
                    new Claim("ModernStore", "User")
                }));
        }
    }
}

