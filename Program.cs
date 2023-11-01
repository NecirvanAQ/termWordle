using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Row
{
    public List<string> letters = new List<string> {"_" , "_", "_", "_", "_"};

    public string guess = "";

    public static bool RealWord(List<string> letters)
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
        Row one = new Row(); Row two = new Row(); Row three = new Row(); Row four = new Row(); Row five = new Row();
        List<Row> rows = new List<Row> { one, two, three, four, five };
        foreach (Row row in rows)
        {
            menu(one, two, three, four, five);

            row.guess = GetGuess(row.guess);

            Console.ReadKey();
        }
    }   

    static void menu(Row one, Row two, Row three, Row four, Row five)
    {
        Console.Clear();
        Console.WriteLine($"\nTERM WORDLE\n");
        PrintRow(one.letters);
        PrintRow(two.letters);
        PrintRow(three.letters);
        PrintRow(four.letters);
        PrintRow(five.letters);
    }

    public static void PrintRow(List<string> letters)
    {
        foreach (string letter in letters)
        {
            Console.Write(letter);
        }
        Console.WriteLine();
    }

    public static string GetGuess(string guess)
    {
        guess = Console.ReadLine();
        return guess;
    }
}