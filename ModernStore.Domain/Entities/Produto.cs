using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Entities
{
   public class Produto : Entity
    {
        public string NomeProduto { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string  Imagem { get; private set; }
        protected Produto() { }

        public Produto(string nomeProduto, decimal preco, int estoque, string imagem)
        {
            NomeProduto = nomeProduto;
            Preco = preco;
            Estoque = estoque;
            Imagem = imagem;
        }
        public void DecrementaQuantidade(int quantidade) => Estoque -= quantidade;
    }
}
