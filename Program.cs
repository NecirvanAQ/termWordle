using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colors.Net;
using static Colors.Net.StringStaticMethods;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string L1 = "_____";
            string L2 = "_____";
            string L3 = "_____";
            string L4 = "_____";
            string L5 = "_____";
            string guess = "";
            string answer = "penis";


            
            for(int i = 0; i < 5; i++)
            {
                menu(L1, L2, L3, L4, L5);
                guess = "";
                
                while (guess.Length != 5 || validCheck(guess) != true)
                {
                    Console.WriteLine("Enter word: ");
                    guess = Console.ReadLine();
                }

                foreach(char c in guess)
                {
                    if(answer.Contains(c))
                }

                switch (Convert.ToString(i))
                {
                    case "0":
                        L1 = guess;
                        break;
                    case "1":
                        L2 = guess;
                        break;
                    case "2":
                        L3 = guess;
                        break;
                    case "3":
                        L4 = guess;
                        break;
                    case "4":
                        L5 = guess;
                        break;

                }

                if (answer == guess)
                {
                    break;
                }
                menu(L1, L2, L3, L4, L5);

            }
            
        }

        static void menu(string L1, string L2, string L3, string L4, string L5)
        {
            
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"       W O R D L E      ");
            Console.WriteLine($"                        ");
            Console.WriteLine($"    {L1[0]}   {L1[1]}   {L1[2]}   {L1[3]}   {L1[4]}   ");
            Console.WriteLine($"    {L2[0]}   {L2[1]}   {L2[2]}   {L2[3]}   {L2[4]}   ");
            Console.WriteLine($"    {L3[0]}   {L3[1]}   {L3[2]}   {L3[3]}   {L3[4]}   ");
            Console.WriteLine($"    {L4[0]}   {L4[1]}   {L4[2]}   {L4[3]}   {L4[4]}   ");
            Console.WriteLine($"    {L5[0]}   {L5[1]}   {L5[2]}   {L5[3]}   {L5[4]}   ");
            Console.WriteLine("");
        }
        static bool validCheck(string guess)
        {
            StreamReader reader = new StreamReader("words.txt");
            // READ THE FIRST LINE
            string? line = reader.ReadLine();

            while(line != null)
            {
                if(line == guess)
                {
                    reader.Close();
                    return true;
                }

                line = reader.ReadLine();
            }
            reader.Close();
            return false;
        }
    }
}