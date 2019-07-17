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
            Console.WriteLine("1 - Enter an Ninja id to search for : ");
            int ninjaId = int.Parse(Console.ReadLine());
            GetNinja(ninjaId);

            GetNinjaList();

            Ninja ninjaPaul = new Ninja();
            GetNinjaEquipmentList(ninjaPaul);
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
    }
}
