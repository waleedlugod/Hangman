using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter;

            List <string> words = Board.Load(@"Words.txt");
            Board.PickWord();

            do
            {
                do
                {
                    letter = Board.GetAnswer();
                } while ((letter == ' ') && (Board.ChosenLetters.Contains(letter)));
                Board.ChosenLetters.Add(letter);
                
                // If character is present in word
                if (Board.WordAsCharArray.Contains(letter))
                {
                    Board.UpdateHiddenWord(letter);
                }
                else
                {
                    Board.IncorrectGuesses++;
                }

                Board.GameDone = Board.IsGameDone();

                Graphics.Draw();

            } while (!Board.GameDone);

            Board.WinCheck();
        }
    }
}
