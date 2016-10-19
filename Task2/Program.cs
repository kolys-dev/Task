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
        static int NumOfRecords;
        static int NumOfErrors;

        static void Main(string[] args)
        {
            NumOfRecords = int.Parse(args[1]);
            NumOfErrors = int.Parse(args[2]);

            string[] BySurnamesMan = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_surnames_man.txt");           
            string[] ByNameMen = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_names_man.txt");
            string[] BySurnameWomen = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_surnames_woman.txt");
            string[] ByNameWomen = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_names_woman.txt");
            string[] ByZipCode = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_zip_codes.txt");
            string[] ByStreets = System.IO.File.ReadAllLines(@"C:\Users\nikol\Desktop\data\data\by_streets.txt");

            switch (args[0])
            {
                
                case "by":
                    output_bel(BySurnamesMan, ByNameMen, ByZipCode, BySurnameWomen, ByNameWomen, ByStreets);
                    break;

                case "ru":
                    Console.WriteLine("ee");
                    break;

                case "en":
                    Console.WriteLine("ee");
                    break;

            }

        }

        public static void output_bel(string[] SurnameMen, string[] NameMen, string[] zip, string[] SurnameWomen, string[] NameWomen,
             string[] Streets)
        {
            string[] phone_index = {"29", "33", "25", "44"};
 
            Random rnd = new Random();
            for (int i = 0; i <= NumOfRecords - 1; i++)
            {
                string homeNumber = String.Format("№{0}-{1}", rnd.Next(0,50), rnd.Next(0,140) );
                if (rnd.Next(0, 2) == 1)
                {
                    Console.WriteLine(SurnameWomen[rnd.Next(SurnameWomen.Length)] + " " + NameWomen[rnd.Next(NameWomen.Length)] +
                        " " + zip[rnd.Next(zip.Length)] + " " + Streets[rnd.Next(Streets.Length)]+" " + homeNumber + " " + "+375" + phone_index[rnd.Next(3)]
                        + rnd.Next(1000000,9999999));
                }

                else
                {
                    Console.WriteLine(SurnameMen[rnd.Next(SurnameMen.Length )] + " " + NameMen[rnd.Next(NameMen.Length)] +
                       " " + zip[rnd.Next(zip.Length)] + " " + Streets[rnd.Next(Streets.Length)]+ " "+ homeNumber + " " + "+375"+ phone_index[rnd.Next(3)] 
                       + rnd.Next(1000000, 9999999));
                }
            }
        }

    }
}
