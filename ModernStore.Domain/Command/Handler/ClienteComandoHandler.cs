using FluentValidator;
using ModernStore.Domain.Command.Inputs;
using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Command.Handler
{
    //InteliCode
   public class ClienteComandoHandler : Notifiable,
        ICommandHandler<RegistraClienteComando>
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEmailService _emailService;


        public ClienteComandoHandler(IClienteRepositorio clienteRepositorio, IEmailService emailService)
        {
            _clienteRepositorio = clienteRepositorio;
            _emailService = emailService;
        }
        public ICommandResult Handle(RegistraClienteComando command)
        {
            //valida CPF
            if (_clienteRepositorio.DocumentoExiste(command.Documento))
            {
                AddNotification("Documento", "Este CPF está em Uso!");
                return null;
            }
            var nome = new Nome(command.PrimeiroNome, command.SegundoNome);
            var documento = new Documento(command.Documento);
            var email = new Email(command.Email);
            var usuario = new Usuario (command.Login, command.Senha, command.ConfirmaSenha);
            var cliente = new Cliente(nome, email,documento,usuario);


            AddNotifications(nome.Notifications);
            AddNotifications(documento.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(usuario.Notifications);
            AddNotifications(cliente.Notifications);


            if (!IsValid())
                return null;

            _clienteRepositorio.Save(cliente);

            _emailService.Send(
                cliente.Nome.ToString(),
                cliente.Email.Endereco,
                string.Format(EmailTemplates.WelcomeEmailTitle, cliente.Nome),
                string.Format(EmailTemplates.WelcomeEmailBody, cliente.Nome)
              );

            return new RegistraClienteComandoResult(cliente.Id, cliente.Nome.ToString());
        }
    }
}
