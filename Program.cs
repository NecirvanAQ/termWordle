using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colors.Net;
using static Colors.Net.StringStaticMethods;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ColoredConsole.WriteLine($"{Red("red")}, {Green("green")}, {Blue("blue")}");
            }


            Console.ReadKey();
        }
    }
}
