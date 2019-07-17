using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaDomain.Classes;
using NinjaDomain.DataModel;

namespace NinjaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("1 - Enter an Ninja id to search for : ");
            int ninjaId = int.Parse(Console.ReadLine());
            GetNinja(ninjaId);

            // 2
            GetNinjaList();

            // 3
            Ninja ninjaPaul = new Ninja();
            GetNinjaEquipmentList(ninjaPaul);

            //4 
            GetNinjaClanMemberList();

        }
        public static Ninja GetNinja(int id)
        {
            using (NinjaContext db = new NinjaContext())
            {
                Ninja ninja = new Ninja();

                foreach (var item in db.Ninjas)
                {
                    if (id == item.Id)
                    {
                        Console.WriteLine(item.ToString());
                        ninja = item;
                    }
                }
                return ninja;
            }
        }

        public static List<Ninja> GetNinjaList()
        {
            Console.WriteLine("\n2 - Return a List of Ninjas");
            List<Ninja> ninjas = new List<Ninja>();
            using (NinjaContext db = new NinjaContext())
            {
                foreach (var item in db.Ninjas)
                {
                    ninjas.Add(item);
                    Console.WriteLine(item.Name);
                }
            }
            return ninjas;

        }

        public static List<NinjaEquipment> GetNinjaEquipmentList(Ninja ninja)
        {
            Console.WriteLine("3 - Return list of equipment for ninja Giles");
            List<NinjaEquipment> ninjaEquipment = new List<NinjaEquipment>();
            using (NinjaContext db = new NinjaContext())
            {
                foreach (var item in db.Ninjas)
                {
                    if (item.Name == "Ninja Giles")
                    {
                        using (NinjaContext db2 = new NinjaContext())
                            foreach (var item2 in db.Equipment)
                            {
                                ninjaEquipment.Add(item2);
                                Console.WriteLine(ninjaEquipment.ToList());
                            }
                    }
                }
            }
            return ninjaEquipment;
        }

        public static List<Clan> GetNinjaClanMemberList()
        {
            List<Clan> clans = new List<Clan>();
            using (NinjaContext db = new NinjaContext())
                foreach (var item in db.Clans)
                {
                    Console.WriteLine(item.ClanName);
                    using (NinjaContext db2 = new NinjaContext())
                        foreach (var item2 in db.Ninjas)
                        {
                            Console.WriteLine(item2.Name);
                        }
                    clans.Add(item);
                }
            return clans;
        }
    }
}
