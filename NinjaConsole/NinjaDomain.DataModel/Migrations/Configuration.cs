namespace NinjaDomain.DataModel.Migrations
{
    using NinjaDomain.Classes;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    internal sealed class Configuration : DbMigrationsConfiguration<NinjaDomain.DataModel.NinjaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaContext context)
        {
            context.Clans.AddOrUpdate(new Clan[]
                {
                new Clan {Id = 1, ClanName = "Giles Clan", Ninjas = new List<Classes.Ninja>()
                {
                // We can add Ninjas to the Clan as we create it
                    new Classes.Ninja
                    {
                        Id = 1,  DateOfBirth = DateTime.Parse("12/02/2006"),
                        EquipmentOwned = new List<NinjaEquipment>()
                        {
                            new NinjaEquipment {Name = "Sweet thing", Id = 1, Type = EquipmentType.Weapon }
                        },
                        Name = "Ninja Giles", ServedInOniwaban = true
                },
                    new Classes.Ninja
                    {
                        Id = 1,  DateOfBirth = DateTime.Parse("02/02/2000"),
                        EquipmentOwned = new List<NinjaEquipment>()
                        {
                            new NinjaEquipment {Name = "Comona XS", Id = 2, Type = EquipmentType.Tool}
                        },
                        Name = "Ninja Fred", ServedInOniwaban = false
                }
                    // Next Clan record goes here
             }
             },
                 new Clan {Id = 2, ClanName = "Ninja Girls Clan", Ninjas = new List<Classes.Ninja>()
                {
                // We can add Ninjas to the Clan as we create it
                    new Classes.Ninja
                    {
                        Id = 1,  DateOfBirth = DateTime.Parse("12/02/1900"),
                        EquipmentOwned = new List<NinjaEquipment>()
                        {
                            new NinjaEquipment {Name = "Sour Grapes", Id = 3, Type = EquipmentType.Weapon }
                        },
                        Name = "Ninja Martha", ServedInOniwaban = true
                },
                     new Classes.Ninja
                    {
                        Id = 1,  DateOfBirth = DateTime.Parse("10/02/1990"),
                        EquipmentOwned = new List<NinjaEquipment>()
                        {
                            new NinjaEquipment {Name = "Fishing Net", Id = 4, Type = EquipmentType.Outwear }
                        },
                        Name = "Ninja Mary", ServedInOniwaban = true
                }
         } } });
        }
    }
}
