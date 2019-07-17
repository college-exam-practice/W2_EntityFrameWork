﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NinjaDomain.Classes
{
    public class Ninja
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOniwaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned { get; set; }
        public System.DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return string.Format("Name {0}", Name);
        }

        public static explicit operator Ninja(List<NinjaEquipment> v)
        {
            throw new NotImplementedException();
        }
    }
    public class Clan
    {
        public int Id { get; set; }
        public string ClanName { get; set; }
        public List<Ninja> Ninjas { get; set; }
    }

    public class NinjaEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]
        public Ninja Ninja { get; set; }

        public override string ToString()
        {
            return string.Format("Name {0}", Name);
        }
    }
}
