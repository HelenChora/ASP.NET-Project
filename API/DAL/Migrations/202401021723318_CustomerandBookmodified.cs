namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerandBookmodified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "total_price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carts", "total_price", c => c.Int(nullable: false));
        }
    }
}
