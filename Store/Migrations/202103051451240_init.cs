namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.purchase",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        purchaseDate = c.DateTime(nullable: false),
                        itemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Item", t => t.itemId, cascadeDelete: true)
                .Index(t => t.itemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchase", "itemId", "dbo.Item");
            DropIndex("dbo.purchase", new[] { "itemId" });
            DropTable("dbo.purchase");
            DropTable("dbo.Item");
        }
    }
}
