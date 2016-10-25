using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class UserGenerator
    {
        private string Country { get; set; }
        private int RecordsCount { get; set; }
        private float NumberOfErrors { get; set; }

        private Random random = new Random();

        public UserGenerator(string country, int recordsCount, float numberOfErrors)
        {
            this.Country = country;
            this.RecordsCount = recordsCount;
            this.NumberOfErrors = numberOfErrors;
        }

        public void PrintRecords()
        {
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

            string[] usSurname = System.IO.File.ReadAllLines(@"data\us_surnames.txt");
            string[] usName = System.IO.File.ReadAllLines(@"data\us_names.txt");
            string[] usStreets = System.IO.File.ReadAllLines(@"data\us_streets.txt");
            string[] usStates = System.IO.File.ReadAllLines(@"data\us_states_and_cities.txt");

            List<string> states = new List<string>();
            List<string> cities = new List<string>();

            foreach (string s in usStates)
            {
                states.Add(s.Remove(s.LastIndexOf('!')));
                cities.Add(s.Remove(0, s.IndexOf('!') + 1));
            }

            switch (Country)
            {

                case "by":
                    OutputBY(bySurnamesMan, byNameMen, byZipCode, bySurnameWomen, byNameWomen, byStreets);
                    break;

                case "ru":
                    OutputRU(ruSurnamesMan, ruNameMen, ruZipCode, ruSurnameWomen, ruNameWomen, ruStreets);
                    break;

                case "en":
                    OutputUS(usSurname, usName, states, cities, usStreets);

                    break;

            }
        }

        public void OutputBY(string[] SurnameMen, string[] NameMen, string[] city, string[] SurnameWomen, string[] NameWomen,
             string[] Streets)
        {
            string[] phone_index = { "29", "33", "25", "44" };

            for (int i = 0; i < RecordsCount; i++)
            {
                string homeNumber = String.Format("№{0}-{1}", random.Next(1, 50), random.Next(1, 140));
                string sW = SurnameWomen[random.Next(SurnameWomen.Length)];
                string nW = NameWomen[random.Next(NameWomen.Length)];
                string sM = SurnameMen[random.Next(SurnameMen.Length)];
                string nM = NameMen[random.Next(NameMen.Length)];
                string town = city[random.Next(city.Length)];
                string zip = random.Next(100000, 999999).ToString();
                string street = Streets[random.Next(Streets.Length)];
                string women = $"{sW} {nW} г.{town} {street} {homeNumber} +375{phone_index[random.Next(phone_index.Length)]}{random.Next(1000000, 9999999)}";
                string men = $"{sM} {nM} г.{town} {street} {homeNumber} +375{phone_index[random.Next(phone_index.Length)]}{random.Next(1000000, 9999999)}";

                bool isMen = Convert.ToBoolean(random.Next(0, 2));
                if (isMen)
                {
                    DistortString(ref men);
                    Console.WriteLine(men);
                }
                else
                {
                    DistortString(ref women);
                    Console.WriteLine(women);
                }
            }
        }

        public void OutputRU(string[] SurnameMen, string[] NameMen, string[] city, string[] SurnameWomen, string[] NameWomen,
             string[] Streets)
        {

            for (int i = 0; i <= RecordsCount - 1; i++)
            {
                string homeNumber = String.Format("№{0}, {1}", random.Next(1, 50), random.Next(1, 140));
                string sW = SurnameWomen[random.Next(SurnameWomen.Length)];
                string nW = NameWomen[random.Next(NameWomen.Length)];
                string sM = SurnameMen[random.Next(SurnameMen.Length)];
                string nM = NameMen[random.Next(NameMen.Length)];
                string town = city[random.Next(city.Length)];
                string zip = random.Next(100000, 999999).ToString();
                string street = Streets[random.Next(Streets.Length)];
                string women = $"{sW} {nW} г.{town} {zip} {street} {homeNumber} +7{random.Next(111, 999)}{random.Next(1000000, 9999999)}";
                string men = $"{sM} {nM} г.{town} {zip} {street} {homeNumber} +7{random.Next(111, 999)}{random.Next(1000000, 9999999)}";

                bool isMen = Convert.ToBoolean(random.Next(0, 2));
                if (isMen)
                {
                    DistortString(ref men);
                    Console.WriteLine(men);
                }

                else
                {

                    DistortString(ref women);
                    Console.WriteLine(women);
                }
            }
        }

        public void OutputUS(string[] Surname, string[] Name, List<string> states, List<string> cities, string[] Streets)
        {
            for (int i = 0; i <= RecordsCount - 1; i++)
            {
                string apt = String.Format("apt.{0}", random.Next(1, 120));
                string homeNumber = String.Format("{0}", random.Next(1000, 20000));


                string name = Name[random.Next(Name.Length)];
                string surname = Surname[random.Next(Surname.Length)];
                string zip = random.Next(00500, 99999).ToString();
                string street = Streets[random.Next(Streets.Length)];
                string phone = $"+1({ random.Next(111, 999)}){ random.Next(1000000, 9999999)}";
                int num = random.Next(50);
                string record = $"{name} {surname} {homeNumber} {street} {apt} {cities[num]}, {states[num]} zipcode:{zip} {phone}";
                DistortString(ref record);
                Console.WriteLine(record);
            }
        }

        public void DistortString(ref string rec)
        {

            for (int i = 0; i < NumberOfErrors; i++)
            {
                var errorNumber = random.Next(0, 2);
                switch (errorNumber)
                {
                    case 0:
                        rec = rec.Insert(random.Next(0, rec.Length), RandomString(1));
                        break;
                    case 1:
                        StringBuilder sb = new StringBuilder(rec);
                        sb[random.Next(0, rec.Length)] = Convert.ToChar(RandomString(1));
                        rec = sb.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$#$%^U&31y7";
            var str = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return str;
        }
    }
}
