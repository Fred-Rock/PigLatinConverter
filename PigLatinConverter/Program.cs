using System;
using System.Collections.Generic;
using System.Linq;

namespace PigLatinConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the user's word.
            Console.WriteLine("Elcomeway avelertray to the Pig Latin Portal! Enter a word and I will convert it to Pig Latin.");
            Console.Write("Enter a word: ");
            string word = Console.ReadLine();

            // Chain methods to get result.
            List<char> allLetters = CreateCharList(word);
            List<char> letterBeforeFirstVowel = CreateLettersBeforeVowelList(allLetters);
            string pigLatinWord = PigLatinify(allLetters, letterBeforeFirstVowel);
            Console.WriteLine(pigLatinWord);
        }

        static List<char> CreateCharList(string word)
        {
            List<char> allLetters = new List<char>();

            foreach (char c in word)
            {
                allLetters.Add(c);
            }

            return allLetters;
        }

        static List<char> CreateLettersBeforeVowelList(List<char> allLetters)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };

            List<char> lettersBeforeFirstVowel = new List<char>();

            foreach (char c in allLetters.ToList())
            {
                if (!vowels.Contains(c))
                {
                    lettersBeforeFirstVowel.Add(c);
                    allLetters.Remove(c);
                }
                else
                {
                    break;
                }
            }

            return lettersBeforeFirstVowel;
        }

        static string PigLatinify(List<char> allLetters, List<char> lettersBeforeFirstVowel)
        {
            allLetters.AddRange(lettersBeforeFirstVowel);
            string lettersInOrder = string.Join("", allLetters);
            string pigLatinWord = lettersInOrder + "ay";

            return pigLatinWord;
        }
    }
}