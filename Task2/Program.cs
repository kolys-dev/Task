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
        
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(args[1]);
            int errorNum = int.Parse(args[2]);

            string[] by_surnames_man = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_surnames_man.txt");           
            string[] by_name_man = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_names_man.txt");
            string[] by_zip = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_zip_codes.txt");
            List<string> byzip = new List<string>();
            List<string> by_names_man = new List<string>();
            List<string> by_families_man = new List<string>();
            List<string> by_names_women = new List<string>();
            List<string> by_families_woman = new List<string>();

            bel_formatting(by_surnames_man, by_families_man);
            bel_formatting(by_zip, byzip);
            bel_formatting(by_name_man, by_names_man);

            switch (args[0])
            {
                
                case "en":
                    Random rnd = new Random();
                    for (int i = 0; i <= numberOfStrings-1; i++)
                    {
                        //int r = rnd.Next(by_families_man.Count);
                        //int n = rnd.Next(list.Count);
                        //int n = rnd.Next(list.Count);
                        Console.WriteLine(by_families_man[rnd.Next(by_families_man.Count-2)] + " " + by_names_man[rnd.Next(by_names_man.Count-2)] +
                            " " +
                            byzip[rnd.Next(byzip.Count-2)]);

                    }
                    

                    break;

                case "ru":
                    Console.WriteLine("ee");
                    break;

                case "by":
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
    }
}
