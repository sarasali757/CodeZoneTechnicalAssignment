namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedQuantityDerivedColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.purchase", "itemId", "dbo.Item");
            DropIndex("dbo.purchase", new[] { "itemId" });
            AddColumn("dbo.Item", "quantity", c => c.Int(nullable: true));
            AlterColumn("dbo.purchase", "itemId", c => c.Int());
            CreateIndex("dbo.purchase", "itemId");
            AddForeignKey("dbo.purchase", "itemId", "dbo.Item", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchase", "itemId", "dbo.Item");
            DropIndex("dbo.purchase", new[] { "itemId" });
            AlterColumn("dbo.purchase", "itemId", c => c.Int(nullable: true));
            DropColumn("dbo.Item", "quantity");
            CreateIndex("dbo.purchase", "itemId");
            AddForeignKey("dbo.purchase", "itemId", "dbo.Item", "id", cascadeDelete: true);
        }
    }
}
