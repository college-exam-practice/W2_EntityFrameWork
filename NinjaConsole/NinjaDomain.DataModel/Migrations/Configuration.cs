namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    internal sealed class Configuration : DbMigrationsConfiguration<NinjaDomain.DataModel.NinjaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaDomain.DataModel.NinjaContext context)
        {
            context.Clans.AddOrUpdate(new Classes.Clan[]
                {
                new Classes.Clan {Id = 1, ClanName = "Giles Clan", Ninjas = new List<Classes.Ninja>()
                {
                // We can add Ninjas to the Clan as we create it
                    new Classes.Ninja
                    {
                        Id = 1,  DateOfBirth = DateTime.Parse("12/02/2006"),
                        EquipmentOwned = new List<Classes.NinjaEquipment>()
                        {
                            new Classes.NinjaEquipment {Name = "Sweet thing", Id = 1, Type = Classes.EquipmentType.Weapon }
                        },
                        Name = "Ninja Giles", ServedInOniwaban = true
                },
                    // Next Clan record goes here
             }
             }
         });
        }
    }
}
