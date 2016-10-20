﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            string[] bySurnamesMan = System.IO.File.ReadAllLines(@"data\by_surnames_man.txt");           
            string[] byNameMen = System.IO.File.ReadAllLines(@"data\by_names_man.txt");
            string[] bySurnameWomen = System.IO.File.ReadAllLines(@"data\by_surnames_woman.txt");
            string[] byNameWomen = System.IO.File.ReadAllLines(@"data\by_names_woman.txt");
            string[] byZipCode = System.IO.File.ReadAllLines(@"data\by_zip_codes.txt");
            string[] byStreets = System.IO.File.ReadAllLines(@"data\by_streets.txt");

            string[] ruSurnamesMan = System.IO.File.ReadAllLines(@"data\ru_surnames_man.txt");
            string[] ruNameMen = System.IO.File.ReadAllLines(@"data\ru_names_man.txt");
            string[] ruSurnameWomen = System.IO.File.ReadAllLines(@"data\ru_surnames_woman.txt");
            string[] ruNameWomen = System.IO.File.ReadAllLines(@"data\ru_names_woman.txt");
            string[] ruZipCode = System.IO.File.ReadAllLines(@"data\ru_cities.txt");
            string[] ruStreets = System.IO.File.ReadAllLines(@"data\ru_streets.txt");

            switch (args[0])
            {
                
                case "by":
                    OutputBY(bySurnamesMan, byNameMen, byZipCode, bySurnameWomen, byNameWomen, byStreets);
                    break;

                case "ru":
                    OutputRU(ruSurnamesMan, ruNameMen, ruZipCode, ruSurnameWomen, ruNameWomen, ruStreets);
                    break;

                case "en":
                    Console.WriteLine("ee");
                    break;

            }

        }

        public static void OutputBY(string[] SurnameMen, string[] NameMen, string[] city, string[] SurnameWomen, string[] NameWomen,
             string[] Streets)
        {
            string[] phone_index = {"29", "33", "25", "44"};

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Random rnd = new Random();



            for (int i = 0; i <= NumOfRecords - 1; i++)
            {
                string homeNumber = String.Format("№{0}-{1}", rnd.Next(0,50), rnd.Next(0,140) );
                string sW = SurnameWomen[rnd.Next(SurnameWomen.Length)];
                string nW = NameWomen[rnd.Next(NameWomen.Length)];
                string sM = SurnameMen[rnd.Next(SurnameMen.Length)];
                string nM = NameMen[rnd.Next(NameMen.Length)];
                string town = city[rnd.Next(city.Length)];
                string zip = rnd.Next(100000, 999999).ToString();
                string street = Streets[rnd.Next(Streets.Length)];
                string women = $"{sW} {nW} г.{town} {street} {homeNumber} +375{phone_index[rnd.Next(phone_index.Length)]}{rnd.Next(1000000, 9999999)}";
                string men = $"{sM} {nM} г.{town} {street} {homeNumber} +375{phone_index[rnd.Next(phone_index.Length)]}{rnd.Next(1000000, 9999999)}";

                if (rnd.Next(0, 2) == 1)
                {
                    Console.WriteLine(men);
                }

                else
                {
                    Console.WriteLine(women);
                }
            }
        }

        public static void OutputRU(string[] SurnameMen, string[] NameMen, string[] city, string[] SurnameWomen, string[] NameWomen,
             string[] Streets)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Random rnd = new Random();

            for (int i = 0; i <= NumOfRecords - 1; i++)
            {
                string homeNumber = String.Format("№{0}, {1}", rnd.Next(0, 50), rnd.Next(0, 140));
                string sW = SurnameWomen[rnd.Next(SurnameWomen.Length)];
                string nW = NameWomen[rnd.Next(NameWomen.Length)]; 
                string sM = SurnameMen[rnd.Next(SurnameMen.Length)];
                string nM = NameMen[rnd.Next(NameMen.Length)];
                string town = city[rnd.Next(city.Length)];
                string zip = rnd.Next(100000, 999999).ToString();
                string street = Streets[rnd.Next(Streets.Length)];
                string women = $"{sW} {nW} г.{town} {zip} {street} {homeNumber} +7{rnd.Next(111, 999)}{rnd.Next(1000000, 99999999)}";
                string men = $"{sM} {nM} г.{town} {zip} {street} {homeNumber} +7{rnd.Next(111, 999)}{rnd.Next(1000000, 99999999)}";

                if (rnd.Next(0, 2) == 1)
                {
                    Console.WriteLine(men);
                }

                else
                {
                    Console.WriteLine(women);
                }
            }
        }

    }
}
