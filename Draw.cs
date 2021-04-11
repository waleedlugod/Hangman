using System;

namespace Hangman
{
    public class Graphics
    {
        public static void Draw ()
        {
            Console.Clear();
            Console.WriteLine("Incorrect guesses made: " + Board.IncorrectGuesses);
            Console.WriteLine("Incorrect guesses left: "
                              + (Board.MAX_INCORRECT_GUESSES - Board.IncorrectGuesses));

            foreach (char character in Board.HiddenWord)
            {
                switch (character)
                {
                    case (char) 0:
                        Console.Write('_');
                        break;
                    default:
                        Console.Write(character);
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}