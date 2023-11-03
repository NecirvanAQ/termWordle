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
    public List<string> colours = new List<string> { "white", "white", "white", "white", "white" };

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
        while (true)
        {
            Random rnd = new Random();

            string answer = SelectWord(rnd);
            List<string> answerList = new List<string> { $"{answer[0]}", $"{answer[1]}", $"{answer[2]}", $"{answer[3]}", $"{answer[4]}" };

            Row one = new Row(); Row two = new Row(); Row three = new Row(); Row four = new Row(); Row five = new Row();
            List<Row> rows = new List<Row> { one, two, three, four, five };

            foreach (Row row in rows)
            {
                while (Row.RealWord(row.guess) != true)
                {
                    menu(one, two, three, four, five);
                    GetGuess(ref row.guess);
                }
                CompareWords(answer, ref row.colours, row.guess);
                Row.UpdateLetters(row.guess, row.letters);

                if (row.guess == answer)
                {
                    menu(one, two, three, four, five);
                    Console.WriteLine("You won!");
                    break;
                }
            }
            menu(one, two, three, four, five);
            Console.WriteLine("the word was " + answer);
            Console.ReadKey();
        }
    }   

    static void menu(Row one, Row two, Row three, Row four, Row five)
    {
        Console.Clear();
        Console.WriteLine($"\nTERM WORDLE\n");
        PrintRow(one.letters, one.colours); PrintRow(two.letters, two.colours);PrintRow(three.letters, three.colours); PrintRow(four.letters, four.colours); PrintRow(five.letters, five.colours);
    }

    public static void PrintRow(List<string> letters, List<string> colours)
    {
        for (int i = 0; i < 5; i++)
        {
            if (colours[i] == "white")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (colours[i] == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            if (colours[i] == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (colours[i] == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write(letters[i]);
        }
        Console.WriteLine();
    }

    public static void CompareWords(string answer, ref List<string> colours, string guess)
    {
        for(int i = 0;i < answer.Length;i++)
        {
            if (!answer.Contains(guess[i]))
            {
                colours[i] = "red";
            }
            else if (guess[i] == answer[i])
            {
                colours[i] = "green";
            }
        }
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