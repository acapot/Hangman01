using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman01
{
    internal class Hangman
    {
        
        List<string> wordsList = new List<string>{"hello","cat","dog","baby","ball","tennis","football","game","alexis","babylon"};
       
        String? randomWord;
        char guessedLetter;
        StringBuilder guessedWord = new StringBuilder();
        StringBuilder checkWord = new StringBuilder();
        int indexInSecretWord;
        int chances = 6;
        bool ifContinue = true;
        char playagain;


        public void RunHangMan()
        {            
            do
            {
                GamePresentation();
                RandomSecretWord();
                GuessWordWithLines();
                ChooseLetterAndCheck();
                playAgain();
                ResetVariables();
            } while (playagain == 'y');
            
        }

        public void ResetVariables()
        {
            
            guessedWord.Clear();
            checkWord.Clear();
            chances = 6;
            ifContinue = true;
        }
        public String RandomSecretWord()
        {
            Console.WriteLine("RandomSecretWord");
            Random random = new Random();
            int randomIndex = random.Next(wordsList.Count);
            randomWord = wordsList[randomIndex];
            Console.WriteLine(randomWord);
            checkWord.Append(randomWord);
            Console.WriteLine(guessedWord);
            return randomWord;
        }

        public void playAgain()
        {
            Console.WriteLine("***************");
            Console.WriteLine("***************");
           
            while (playagain != 'y' && playagain != 'n')
            {
                Console.WriteLine("Do you want to play again (y/n)");
                playagain = Console.ReadKey(true).KeyChar;
            }
            Console.Clear();

        }
        public void GuessWordWithLines()
        {
            guessedWord.Append('_', randomWord.Length);
            Console.WriteLine("It is a word with  " + (guessedWord.Length)+ " letters:");
            Console.WriteLine(guessedWord);

        }


        public void GamePresentation()
        {
            Console.WriteLine("||================================================||");
            Console.WriteLine("|| ---Welcome to Hangman Game---                   ||");
            Console.WriteLine("|| You have to guess the secret word in 6 chances ||");            
            Console.WriteLine("||================================================||");
        }

        public void ChooseLetterAndCheck()
        {

            while (guessedWord.ToString().Contains('_') && ifContinue)
            {
                Console.WriteLine("***************");
                Console.WriteLine("Choose a letter");
                guessedLetter = Console.ReadLine()[0];
                CheckLetterInSecretWord();
                CheckWin();
            }
            
            //LinesOfSecretWord();
        }

        public void CheckWin()
        {
            if (chances == 0)
            {
                ifContinue = false;
                Console.WriteLine("Game Over");
            }else if(guessedWord.ToString().Equals(randomWord.ToString()))
            {
                ifContinue = false;
                Console.WriteLine("Congratulation you Won !!!!!");
            }
        }
        public void CheckLetterInSecretWord()
        {

            //while(guessedWord)
            if (checkWord.ToString().Contains(guessedLetter))
            {
                Console.WriteLine("Nice :)");
                while (checkWord.ToString().Contains(guessedLetter))
                {                    
                    indexInSecretWord = checkWord.ToString().IndexOf(guessedLetter);
                    checkWord[indexInSecretWord] = '_';
                    guessedWord[indexInSecretWord] = guessedLetter;

                }
            }
            else {
                chances--;
                Console.WriteLine("Wrong letter, try again");
                Console.WriteLine("you have "+ chances +" chances left!");
                
            }

            Console.WriteLine(guessedWord);
        }
    }
}
