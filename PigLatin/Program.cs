using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatin
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string userAnswer, userText;
            string[] phrase;

            Console.WriteLine("Welcome to the Pig Latin Translator!");

            while (true)
            {
                //Prompt user for text to translate
                Console.WriteLine("Enter a line of text to be translated: ");
                userText = Console.ReadLine().ToLower();

                //validate that user has entered a word
                if (userText == "")
                {
                    Console.WriteLine("That is not valid input.");
                    continue;
                }
                //ALSO can check for numbers and symbolds here

                //break up User's input into an array of strings
                phrase = userText.Split(' ');

                //translate each word in array to Pig Latin and print to console
                Translate(phrase);

                Console.WriteLine(" ");

                //Ask if they want to translate another word/phrase
                Console.WriteLine("Would you like to translate another word? Y/N");
                userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer == "N")
                {
                    break;
                }
            }
        }

        public static void Translate(string[] phrase)
        {
            foreach (var word in phrase)
            {
                //check if word has no vowels
                if (!Regex.IsMatch(word, @"\w[aeiouAEIOU]"))
                {
                    CheckForNoVowels(word);
                }
                //check if it starts with a vowel
                else if (Regex.IsMatch(word, @"\b[aeiouAEIOU]\w*"))
                {
                    CheckVowel(word);
                }
                //word must start with a consonant
                else 
                {
                    CheckConsonant(word);
                }
            }
        }

        public static void CheckForNoVowels(string word)
        {
            //word doesn't contain any vowels, so add -way to end of the word
            Console.Write(word + "way" + " ");
        }

        public static void CheckVowel(string word)
        {
            //word starts with a vowel, add -way to the end of the word
            Console.Write(word + "way" + " ");
        }

        public static void CheckConsonant(string word)
        {
            while (Regex.IsMatch(word, @"\b[^aeiouAEIOU]\w*"))
            {
                //word starts with a consonant, move all consonants before first vowel to the end of the word and add -ay
                string firstLetter = word.Substring(0, 1);
                string restOfWord = word.Substring(1, word.Length - 1);
                word = restOfWord + firstLetter;
            }
            Console.Write(word + "ay" + " ");
        }  
    }
}
