namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerandAllAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        book_name = c.String(nullable: false),
                        stock = c.Int(nullable: false),
                        unit_price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.book_id);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        cart_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        book_id = c.Int(nullable: false),
                        total_price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cart_id)
                .ForeignKey("dbo.Books", t => t.book_id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.book_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        customer_name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        contact = c.String(nullable: false),
                        location = c.String(nullable: false),
                        user_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.customer_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        book_id = c.Int(nullable: false),
                        total_price = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.Books", t => t.book_id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.book_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        user_name = c.String(),
                        password = c.String(),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        token_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        token_key = c.String(),
                        created = c.DateTime(nullable: false),
                        expired = c.DateTime(),
                    })
                .PrimaryKey(t => t.token_id)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "user_id", "dbo.Users");
            DropForeignKey("dbo.Tokens", "user_id", "dbo.Users");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "book_id", "dbo.Books");
            DropForeignKey("dbo.Carts", "book_id", "dbo.Books");
            DropIndex("dbo.Tokens", new[] { "user_id" });
            DropIndex("dbo.Orders", new[] { "book_id" });
            DropIndex("dbo.Orders", new[] { "customer_id" });
            DropIndex("dbo.Customers", new[] { "user_id" });
            DropIndex("dbo.Carts", new[] { "book_id" });
            DropIndex("dbo.Carts", new[] { "customer_id" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Carts");
            DropTable("dbo.Books");
        }
    }
}
