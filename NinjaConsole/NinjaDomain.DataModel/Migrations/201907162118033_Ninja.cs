namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    public partial class Ninja : DbMigration
    {
        public int Id { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public List<Classes.NinjaEquipment> EquipmentOwned { get; internal set; }
        public string Name { get; internal set; }
        public bool ServedInOniwaban { get; internal set; }

        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClanName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServedInOniwaban = c.Boolean(nullable: false),
                        ClanId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clans", t => t.ClanId, cascadeDelete: true)
                .Index(t => t.ClanId);
            
            CreateTable(
                "dbo.NinjaEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Ninja_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ninjas", t => t.Ninja_Id, cascadeDelete: true)
                .Index(t => t.Ninja_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquipments", "Ninja_Id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "ClanId", "dbo.Clans");
            DropIndex("dbo.NinjaEquipments", new[] { "Ninja_Id" });
            DropIndex("dbo.Ninjas", new[] { "ClanId" });
            DropTable("dbo.NinjaEquipments");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Clans");
        }
    }
}
