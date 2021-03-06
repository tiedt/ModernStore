﻿using Dapper;
using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Infra.Repositories
{
   public class ProdutoRepositories : IProdutoRepositorio
    {
        private readonly ModernStoreDataContext _context;

        public ProdutoRepositories(ModernStoreDataContext context)
        {
            _context = context;
        }
        public Produto Get(int id)
        {
            return _context
         .Produtos
         .AsNoTracking()
         .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetProdutoListaComandoResultado> Get()
        {
            var query = "select [id],[NomeProduto],[Preco],[Imagem] from [Produto]";
            using (var conn = new SqlConnection(@"Server=DATAD001588\SQLEXPRESS03;Database=ModernStoreDB;User ID=UsuarioModern;Password=modern;Trusted_Connection=True"))
            {
                conn.Open();
                return conn.Query<GetProdutoListaComandoResultado>(query);
            }
        }
    }
}
