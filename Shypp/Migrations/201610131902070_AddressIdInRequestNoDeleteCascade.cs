namespace Shypp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressIdInRequestNoDeleteCascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Requests", new[] { "Address_Id" });
            RenameColumn(table: "dbo.Requests", name: "Address_Id", newName: "AddressId");
            AlterColumn("dbo.Requests", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Requests", "AddressId");
            AddForeignKey("dbo.Requests", "AddressId", "dbo.Addresses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Requests", new[] { "AddressId" });
            AlterColumn("dbo.Requests", "AddressId", c => c.Int());
            RenameColumn(table: "dbo.Requests", name: "AddressId", newName: "Address_Id");
            CreateIndex("dbo.Requests", "Address_Id");
            AddForeignKey("dbo.Requests", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
