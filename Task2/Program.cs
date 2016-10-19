using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static int numberOfStrings;
        static int errorNum;

        static void Main(string[] args)
        {
            numberOfStrings = int.Parse(args[1]);
            errorNum = int.Parse(args[2]);

            string[] by_surnames_man = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_surnames_man.txt");           
            string[] by_name_man = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_names_man.txt");
            string[] by_surnames_woman = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_surnames_woman.txt");
            string[] by_name_women = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_names_woman.txt");
            string[] by_zip = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_zip_codes.txt");

            List<string> byzip = new List<string>();
            List<string> by_names_man = new List<string>();
            List<string> by_families_man = new List<string>();
            List<string> by_names_women = new List<string>();
            List<string> by_families_women = new List<string>();

            bel_formatting(by_surnames_man, by_families_man);
            bel_formatting(by_zip, byzip);
            bel_formatting(by_name_man, by_names_man);

            bel_formatting(by_surnames_woman, by_families_women);
            bel_formatting(by_name_women, by_names_women);

            switch (args[0])
            {
                
                case "by":
                    output_bel(by_families_man, by_names_man, byzip, by_families_women, by_names_women);
                    break;

                case "ru":
                    Console.WriteLine("ee");
                    break;

                case "en":
                    Console.WriteLine("ee");
                    break;

            }

        }

        public static void bel_formatting(string[] mas, List<string> list )
        {
            foreach (string str in mas)
            {
                string st;
                st = str.Replace('-', ' ').Replace('і', 'i').Replace('І', 'I');

                list.Add(st);
            
            }
        }

        public static void output_bel(List<string> surname_man, List<string> name_man, List<string> zip, List<string> surname_women, List<string> name_women)
        {
            Random rnd = new Random();
            for (int i = 0; i <= numberOfStrings - 1; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    Console.WriteLine(surname_women[rnd.Next(surname_women.Count)] + " " + name_women[rnd.Next(name_women.Count)] +
                        " " + zip[rnd.Next(zip.Count)]);
                }

                else
                {
                    Console.WriteLine(surname_man[rnd.Next(surname_man.Count )] + " " + name_man[rnd.Next(name_man.Count)] +
                       " " + zip[rnd.Next(zip.Count)]);
                }
            }
        }

    }
}
