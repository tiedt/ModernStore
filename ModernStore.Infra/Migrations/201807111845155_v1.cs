namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome_PrimeiroNome = c.String(nullable: false, maxLength: 60),
                        Nome_SegundoNome = c.String(nullable: false, maxLength: 60),
                        DataNascimento = c.DateTime(nullable: false),
                        Documento_Numero = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email_Endereco = c.String(nullable: false, maxLength: 160),
                        Usuario_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        NumeroPedido = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        Status = c.Int(nullable: false),
                        FreteGratis = c.Decimal(nullable: false, storeType: "money"),
                        Desconto = c.Decimal(nullable: false, storeType: "money"),
                        Cliente_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id, cascadeDelete: true)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Decimal(nullable: false, storeType: "money"),
                        Produto_Id = c.Long(nullable: false),
                        Pedido_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomeProduto = c.String(nullable: false, maxLength: 80),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Imagem = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ItemPedido", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Pedido", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.ItemPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemPedido", new[] { "Produto_Id" });
            DropIndex("dbo.Pedido", new[] { "Cliente_Id" });
            DropIndex("dbo.Cliente", new[] { "Usuario_Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.Usuario");
            DropTable("dbo.Cliente");
        }
    }
}
