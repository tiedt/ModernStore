using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Repositories
{
    public class ClienteRepositories : IClienteRepositorio
    {
        private readonly ModernStoreDataContext _context;

        public ClienteRepositories(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentoExiste(string documento)
        {
            return _context.Clientes.Any(x => x.Documento.Numero == documento);
        }

        public Cliente Get(long id)
        {
            return _context
                   .Clientes
                   .Include(x => x.Usuario)
                   .FirstOrDefault(x => x.Id == id);
        }

        public GetClienteComandoResultado Get(string documento)
        {
            return _context
                .Clientes
                .Include(x => x.Documento)
                .AsNoTracking()
                .FirstOrDefault()
                .Select(x => new GetClienteComandoResultado
                {
                Nome = x.Nome.ToString(),
                Documento = x.Documento.Numero,
                Ativo = x.Usuario.Ativo,
                Email = x.Email.Endereco,
                Senha = x.Usuario.Senha,
                Login = x.Usuario.Login

            })
            .FirstOrDefault(x => x.Documento == documento);
        }

        public void Save(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }
    }
}
