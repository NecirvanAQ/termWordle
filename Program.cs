using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Tracing;

class Row
{
    public List<string> letters = new List<string> {"_" , "_", "_", "_", "_"};

    public string guess = "";

    public static bool RealWord(string guess)
    {
        StreamReader sr = new StreamReader("words.txt");
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            if (line == guess)
            {
                return true;
            }
        }
        return false;
    }

    public static void UpdateLetters(string guess, List<string> letters)
    {
        try
        {
            for (int i = 0; i != 5; i++)
            {
                letters[i] = Convert.ToString(guess[i]);
            }
        } catch (Exception e) { };
    }

}
class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        string answer = SelectWord(rnd);
        List<string> answerList = new List<string> {$"{answer[0]}", $"{answer[1]}", $"{answer[2]}", $"{answer[3]}", $"{answer[4]}" };

        Row one = new Row(); Row two = new Row(); Row three = new Row(); Row four = new Row(); Row five = new Row();
        List<Row> rows = new List<Row> { one, two, three, four, five };

        foreach (Row row in rows)
        {
            menu(one, two, three, four, five);
            Console.WriteLine(answer);

            while (Row.RealWord(row.guess) != true)
            {
                GetGuess(ref row.guess);
                Row.UpdateLetters(row.guess, row.letters);
            }

            if (row.guess == answer)
            {
                menu(one, two, three, four, five);
                Console.WriteLine("You won!");
                break;
            }
        }
        Console.ReadKey();
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

    public static string GetGuess(ref string guess)
    {
        guess = Console.ReadLine();
        return guess;
    }

    public static string SelectWord(Random rnd)
    {
        StreamReader sr = new StreamReader("words.txt");
        int t = rnd.Next(1, 1000);
        int i = 0;
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();

            if (i == t)
            {
                sr.Close();
                return line;
            }
            i++;
        }
        sr.Close();
        return "error";
    }
}