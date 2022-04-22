using System;
using HangmanRenderer.Renderer;
namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guessProgress;
        private int _lives;
        //private string letter;
        //private string correctguessed;
        //private int playerguess;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }
        public void Run()
        {
            _lives = 6;
            _renderer.Render(5, 5, 6);
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 17);
            Console.ForegroundColor = ConsoleColor.Green;
            //  Console.Write("_");
            // var nextGuess = Console.ReadLine();
            Random random = new Random();
            string[] wordList = new string[] { "Company", "words", "love", "computer", "house", "school", "playstore", "playstation", "laptop", "bread", "food", "typing", "reading", "water", "nap", "phone", "paper", "toilet", "table", "pen" };
            var index = random.Next(0, 19);
            string wordToGuess = wordList[index];
            char[] guess = wordToGuess.ToCharArray();

            for (int i = 0; i < guess.Length; i++)
            {
                _guessProgress += "*";
                Console.SetCursorPosition(0, 17);
            }

            while (_lives > 0)
            {
                _renderer.Render(5, 5, _lives);
                Console.SetCursorPosition(0, 17);
                char playersGuess = char.Parse(Console.ReadLine());
                char[] guessProgressArray = _guessProgress.ToCharArray();

                //Console.SetCursorPosition(0, 17);
                bool match = false;
                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == playersGuess)
                    {
                        guessProgressArray[i] = guess[i];
                        match = true;
                        //Console.WriteLine("You win");
                    }
                }

                _guessProgress = new string(guessProgressArray);
                Console.SetCursorPosition(0, 18);
                Console.WriteLine(_guessProgress);

                if (!match)
                {
                    _lives--;
                    _renderer.Render(5, 5, _lives);
                  
                }


                Console.SetCursorPosition(2, 22);

                if (_guessProgress == wordToGuess)
                {
                    Console.WriteLine($"You won with {_lives} left.");


                }

            }

        }
    }
}
