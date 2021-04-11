using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public static class Board
    {
        public const int MAX_INCORRECT_GUESSES = 5;
        private static List<string> words = new List<string>();
        private static List<char> chosenLetters = new List<char>();
        private static char[] wordAsCharArray;
        private static char[] hiddenWord;
        private static bool gameDone = false;
        private static int incorrectGuesses = 0;


        public static string PickWord()
        {
            Random rnd = new Random();
            int index = rnd.Next(1, words.Count);
            string word;

            word = Words[index];

            WordAsCharArray = word.ToCharArray();
            HiddenWord = new char[WordAsCharArray.Length];
            
            return word;
        }

        public static List <string> Load(string fileName)
        {
            List <string> result = null;
            System.IO.TextReader textIn = new System.IO.StreamReader(fileName);

            // First line of file is dedicated to how many words are in the file
            string wordCountString = textIn.ReadLine();
            int wordCount = int.Parse(wordCountString);

            for (int i = 0; i < wordCount; i++)
            {
                string word = textIn.ReadLine();
                words.Add(word);
            }
            
            textIn.Close();
                
            return result;
        }

        public static void UpdateHiddenWord(char letter)
        {
            for (int i = 0; i < WordAsCharArray.Length; i++)
            {
                if (WordAsCharArray[i] == letter)
                {
                    HiddenWord[i] = letter;
                }
            }
        }

        public static void WinCheck()
        {
            foreach (char character in HiddenWord)
            {
                if (character == (Char) 0)
                {
                    Console.WriteLine("You lost...");
                    return;
                }
            }
            Console.WriteLine("You won!");
        }

        public static char GetAnswer()
        {
            string input;
            char letter;
            bool isValid = false;

            do
            {
                Console.Write("Enter a letter you think is in the word: ");
                input = Console.ReadLine();
                isValid = char.TryParse(input, out letter);
            } while (!isValid);

            return letter;
        }

        public static bool IsGameDone()
        {
            if (Board.IncorrectGuesses >= Board.MAX_INCORRECT_GUESSES)
            {
                return true;
            }
            else
            {
                foreach (char character in Board.HiddenWord)
                {
                    if (character == (Char) 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static List<string> Words
        {
            get {return words;}
            set {words = value;}
        }

        public static List<char> ChosenLetters
        {
            get {return chosenLetters;}
            set {chosenLetters = value;}
        }

        public static char[] WordAsCharArray
        {
            get {return wordAsCharArray;}
            set {wordAsCharArray = value;}
        }

        public static char[] HiddenWord
        {
            get {return hiddenWord;}
            set {hiddenWord = value;}
        }

        public static bool GameDone
        {
            get {return gameDone;}
            set {gameDone = value;}
        }

        public static int IncorrectGuesses
        {
            get {return incorrectGuesses;}
            set {incorrectGuesses = value;}
        }
    }
}