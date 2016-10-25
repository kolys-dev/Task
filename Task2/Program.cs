using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var userGenerator = new UserGenerator(args[0], int.Parse(args[1]), float.Parse(args[2]));

            userGenerator.PrintRecords();
        }
    }
}
