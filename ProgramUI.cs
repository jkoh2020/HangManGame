using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HangManGame
{
    public class ProgramUI
    {
        int tries = 6;
        List<string> letterGuessed = new List<string>();
        string guess;

        public void TitleName()
        {

            HangManRepo hangManRepo = new HangManRepo(); // How to call the methods from the Repo

            string lines = System.IO.File.ReadAllText(@"C:\ElevenFiftyProjects\SDLessons69\HangManGame\Hangman_words.txt"); // list of words from text box
            List<string> wordBank = lines.ToLower().Split(',').ToList(); // seperate words

            Random random = new Random(); // random word
            int randomWord = random.Next(0, 9);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hangman Game");
            Console.WriteLine("----------------------");
            Console.WriteLine("|         |           ");
            Console.WriteLine("|         O           ");
            Console.WriteLine("|        /|\\         ");
            Console.WriteLine("|       / | \\        ");
            Console.WriteLine("|         |           ");
            Console.WriteLine("|        / \\         ");
            Console.WriteLine("|       /   \\        ");
            Console.WriteLine($"\nThere are {wordBank[randomWord].Length} letters in the word\n\n");
            hangManRepo.isLetter(wordBank[randomWord], letterGuessed); // it shows letter lines
            Console.WriteLine(hangManRepo.isLetter(wordBank[randomWord], letterGuessed));
            Console.WriteLine("\nPress any key(or enter) to start \n");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
            

            while (tries >= 0) // it runs until 0 lives
            {


                // Console.WriteLine(wordBank[randomWord]); // Cheat sheet: it shows the word you are looking for
                
                Console.WriteLine($"You have {tries} guesses left"); // This shows how many lives are left
                
               

                
                Console.WriteLine("\nLetters guessed:"); // This shows letters you have entered
                 foreach (string i in letterGuessed)
                  {
                      Console.Write(i  + ", ");
                    
                   }


                Console.WriteLine(hangManRepo.isLetter(wordBank[randomWord], letterGuessed)); // It shows letter you have guessed correct
                Console.WriteLine("\n\n\nPlease type your letter:\n");

                guess = Console.ReadLine().ToLower();//This uses the Users input
                Console.Clear();

              
                if (letterGuessed.Contains(guess)) // it shows dupulicate letter
                {
                    Console.WriteLine($"You already entered [{guess}]");
                    Console.WriteLine("Try a different letter\n\n");
                    continue;
                }

                letterGuessed.Add(guess); // add letter to the list if you get a correct letter
                if (hangManRepo.isWord(wordBank[randomWord], letterGuessed))
                {

                    Console.Clear();
                     
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(wordBank[randomWord]);
                    Console.WriteLine();
                    Console.WriteLine("Congratulations! You Won!");
                    hangManRepo.WinningSound();
                    Console.ReadLine();
                    break;
                }

                else if (wordBank[randomWord].Contains(guess)) // to check word bank that it contains the guess letter
                    {

                }

                else
                {

                    tries -= 1; // it takes a life away

                }



                switch (tries) // drawing
                {
                    
                    case 6:
                        
                        Console.WriteLine(@"---------------------");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        break;

                    case 5:
                        
                        Console.WriteLine(@"---------------------");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|         O          ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        break;

                    case 4:
                        
                        Console.WriteLine(@"---------------------");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|         O          ");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|         |          ");
                        Console.WriteLine(@"|                    ");
                        Console.WriteLine(@"|                    ");
                        break;

                    case 3:
                        Console.WriteLine(@"----------------------");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|         O           ");
                        Console.WriteLine(@"|        /|           ");
                        Console.WriteLine(@"|       / |           ");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|                     ");
                        Console.WriteLine(@"|                     ");
                        break;

                    case 2:
                        Console.WriteLine(@"----------------------");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|         O           ");
                        Console.WriteLine(@"|        /|\          ");
                        Console.WriteLine(@"|       / | \         ");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|                     ");
                        Console.WriteLine(@"|                     ");
                        break;

                    case 1:
                        Console.WriteLine(@"----------------------");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|         O           ");
                        Console.WriteLine(@"|        /|\          ");
                        Console.WriteLine(@"|       / | \         ");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|        /            ");
                        Console.WriteLine(@"|       /             ");
                        break;

                    case 0:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"----------------------");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|         O           ");
                        Console.WriteLine(@"|        /|\          ");
                        Console.WriteLine(@"|       / | \         ");
                        Console.WriteLine(@"|         |           ");
                        Console.WriteLine(@"|        / \           ");
                        Console.WriteLine(@"|       /   \          " + "\n\n");
                        
                        Console.WriteLine("Game Over! Try again next time when Covid-19 is over.");
                        hangManRepo.LoserSound();
                        Console.ReadLine();
                        tries = tries - 1;
                        break;

                    default:
                        Console.WriteLine("If you are seeing this line, there is an error");
                        break;
                }

            }
        }

    }

}

