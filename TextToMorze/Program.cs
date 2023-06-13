using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToMorze
{
    internal class Program
    {
        static char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
        'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ' };

        static string[] morseCode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
        "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----",
        ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "/" };
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: Если ввод азбуки Морзе то символ каждой буквы вводить через пробел ");
            string input = Console.ReadLine().ToUpper();

            if (IsMorseCode(input))
            {
                string output = MorseCodeToText(input);
                Console.WriteLine("Текст: " + output);
            }
            else
            {
                string output = TextToMorseCode(input);
                Console.WriteLine("Текст в азбуке Морзе: " + output);
            }

            Console.ReadLine();
        }

        static bool IsMorseCode(string input)
        {
            foreach (char c in input)
            {
                if (c != '.' && c != '-' && c != ' ' && c != '/')
                {
                    return false;
                }
            }
            return true;
        }

        static string MorseCodeToText(string input)
        {
            string[] words = input.Split(new string[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
            string output = "";
            foreach (string word in words)
            {
                string[] letters = word.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string letter in letters)
                {
                    int index = Array.IndexOf(morseCode, letter);
                    if (index != -1)
                    {
                        output += alphabet[index];
                    }
                }
                output += " ";
            }
            return output.Trim();
        }

        static string TextToMorseCode(string input)
        {
            string output = "";
            foreach (char c in input)
            {
                int index = Array.IndexOf(alphabet, c);
                if (index != -1)
                {
                    output += morseCode[index] + " ";
                }
                else
                {
                    output += c + " ";
                }
            }
            return output.Trim();
        }
    }
}
