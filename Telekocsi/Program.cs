using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Program
    {
        static List<Ut> utak = new List<Ut>();

        static void Main(string[] args)
        {
            //2. feladat

            foreach (var item in File.ReadAllLines("bejegyzések.txt"))
            {
                utak.Add(new Ut(item));
            }

            //StreamReader reader = new StreamReader("bejegyzések.txt");
            //while (!reader.EndOfStream)
            //{
            //    string sor = reader.ReadLine();
            //    utak.Add(new Ut(sor));
            //}
            //reader.Close();

            //3. feladat

            Console.WriteLine($"3. feladat: Bejegyzések száma: {utak.Count()}");

            //4.feladat

            Console.WriteLine($"4. feladat: Utasok száma: {utak.Count(x=>x.tipusa == Felhasznalo.utas)}");

            // 5. feladat

            var sofor = utak.FindAll(x => x.tipusa == Felhasznalo.sofőr).ToList();
            int max = 0;
            foreach (var item in sofor)
            {
                if (item.Felhasznalo_id > max)
                {
                    max = item.Felhasznalo_id;
                }
            }

            Console.WriteLine($"%. feladat: Legnagyobb sofőr azonosító {max}");

            // 6. feladat
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Kérem a bejegyzés napjának sorszámát: ");
            int napSzam;
            try
            {
                napSzam = int.Parse(Console.ReadLine());
                
            }
            catch 
            {
                napSzam = 7;
            }
            Console.WriteLine("Kérem az úticél azonosítóját: ");
            int azonSzam;
            try
            {
            azonSzam = int.Parse(Console.ReadLine());

            }
            catch 
            {

                azonSzam = 7;
            }
            // 7. feladat

            bool volt = false;

            foreach (var item in sofor)
            {
                int nap = int.Parse(item.Datum.Substring(8));
                if (nap == napSzam && item.Uticel_id == azonSzam)
                {
                    volt = true;
                    Console.WriteLine($"A megadott napon (2018.01.{napSzam}) a megadott úticélhoz ({azonSzam}) volt bejegyzés!");
                    break;


                }
              

            }
            if (!volt)
            {
                Console.WriteLine($"A megadott napon (2018.01.{napSzam}) a megadott úticélhoz ({azonSzam}) nem volt bejegyzés!");

             }

            // 8. feladat
            Console.WriteLine("8. feladat: stat.txt...");
            var utasok = utak.FindAll(x => x.tipusa == Felhasznalo.utas).ToList();
            Dictionary<int, int> stat = new Dictionary<int, int>();
            foreach (var item in utasok)
            {
                if (!stat.ContainsKey(item.Felhasznalo_id))
                {
                    stat.Add(item.Felhasznalo_id, 1);
                }
                else
                {
                    stat[item.Felhasznalo_id]++;
                }
            }

            FileStream file = new FileStream("stat.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            foreach (var item in stat)
            {
                if (item.Value > 15)
                {
                writer.WriteLine(item.Key+ " -> "+item.Value+" db");

                }
            }
            writer.Close();
            file.Close();
                Console.ReadKey();
        }
    }
}
