namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataAnotationsOnModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.purchase", "itemId", "dbo.Item");
            DropIndex("dbo.purchase", new[] { "itemId" });
            AlterColumn("dbo.Item", "name", c => c.String(nullable: false, maxLength: 225));
            AlterColumn("dbo.Item", "quantity", c => c.Int());
            AlterColumn("dbo.purchase", "itemId", c => c.Int(nullable: false));
            CreateIndex("dbo.purchase", "itemId");
            AddForeignKey("dbo.purchase", "itemId", "dbo.Item", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.purchase", "itemId", "dbo.Item");
            DropIndex("dbo.purchase", new[] { "itemId" });
            AlterColumn("dbo.purchase", "itemId", c => c.Int());
            AlterColumn("dbo.Item", "quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "name", c => c.String());
            CreateIndex("dbo.purchase", "itemId");
            AddForeignKey("dbo.purchase", "itemId", "dbo.Item", "id");
        }
    }
}
