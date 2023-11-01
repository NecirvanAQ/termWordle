using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Column
{
    List<string> letters = new List<string> {"" , "", "", "", ""};

    static bool RealWord(List<string> letters)
    {
        StreamReader sr = new StreamReader("words.txt");
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            if (line == Convert.ToString(letters))
            {
                return true;
            }
        }
        return false;
    }
}
class Program
{
    static void Main(string[] args)
    {
        
    }

}