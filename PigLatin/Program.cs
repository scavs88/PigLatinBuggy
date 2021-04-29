using System;
using System.Linq;

namespace PigLatin
{
    public class Program
    {

        //overall, user input is being stored and passed around to too many different variables.  Input should be stored in one value and used from that value 
        //, processes should be in some sort of order in terms of where information is flowing
        static void Main(string[] args)
        {
            Console.WriteLine("Please input a word or sentence to translate to pig Latin");
            string userInput = Console.ReadLine().ToLower().Trim();
            string translation = ToPigLatin(userInput);
            Console.WriteLine(translation); // not translating
        }

        //public static string GetInput(string prompt)
        //{
        //    Console.WriteLine(prompt);                   <------------Easier and more clear write in main
        //    string input = Console.ReadLine().ToLower().Trim();
        //    return input;
        //}

        

        public static string ToPigLatin(string word)
        {
            char[] specialChars = { '@', '.', '-', '$', '^', '&' }; //works, seems over complicated
            word = word.ToLower();
            foreach(char c in specialChars)
            {


                if (word.Contains(c)) //shortened this to remove redundant foreach loop
                {
                        Console.WriteLine("That word has special characters, we will return it as is");
                        return word;
                }
                
                
            }


            static bool IsVowel(char c)
            {
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

                return c.ToString() == vowels.ToString();
            }


            bool noVowels = true;
            foreach(char letter in word)
            {
                if (IsVowel(letter))
                {
                    noVowels = false;
                }
            }

            if (noVowels)
            {
                return word; 
            }

            char firstLetter = word[0];
            string output = "placeholder";
            if (IsVowel(firstLetter) == true)
            {
                output = word + "ay";
            }
            else
            {
                int vowelIndex = -1;
                //Handle going through all the consonants
                for (int i = 0; i <= word.Length; i++)
                {
                    if (IsVowel(word[i]) == true)
                    {
                        vowelIndex = i;
                        break;
                    }
                }

                string sub = word.Substring(vowelIndex + 1);
                string postFix = word.Substring(0, vowelIndex -1);

                output = sub + postFix + "ay";
            }

            return output;
        }
    }
}
