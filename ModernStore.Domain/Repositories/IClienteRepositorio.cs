using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Repositories
{
    public interface IClienteRepositorio
    {
        Cliente Get(long id);
        Cliente GetByUsername(string username);
        GetClienteComandoResultado Get(string usuario);
        void Save(Cliente cliente);
        void Update(Cliente cliente);
        bool DocumentoExiste(string documento);
    }
}
