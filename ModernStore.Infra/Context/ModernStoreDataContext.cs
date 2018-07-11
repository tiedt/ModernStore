using ModernStore.Domain.Entities;
using ModernStore.Infra.Mapeamentos;
using System.Data.Entity;

namespace ModernStore.Infra.Context
{
    public class ModernStoreDataContext : DbContext
    {
        public ModernStoreDataContext() : base("Server=localhost\\SQLEXPRESS03;Database=ModernStoreDB;Trusted_Connection=True;")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false; 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ItemPedidoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
