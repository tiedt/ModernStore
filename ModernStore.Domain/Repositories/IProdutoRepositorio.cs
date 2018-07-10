﻿using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Repositories
{
   public interface IProdutoRepositorio
    {
        Produto Get(int id);
        IEnumerable<GetProdutoListaResultado> Get();
    }
}
