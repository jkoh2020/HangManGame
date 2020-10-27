using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace HangManGame
{
    public class HangManRepo 
    {
        
        public string isLetter(string word, List<string> letterGuessed) // to see letter is correct
        {
            string correctletters = "        ";
            for (int i = 0; i < word.Length; i++)
            {
                string c = Convert.ToString(word[i]);
                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "  _  ";
                }

            }
            return correctletters + "\n\n";

        }

        public bool isWord(string word, List<string> letterGuessed) // to see you get the right word
        {
            bool a = false;
            for (int i = 0; i < word.Length; i++)
            {
                string c = Convert.ToString(word[i]);
                if (letterGuessed.Contains(c))
                {
                    a = true;
                }
                else
                {
                    return a = false;
                }
            }

            return a;
        }

        public void WinningSound() // method: it plays the winning sound when you win a game 
        {
            var myPlayer = new SoundPlayer();
            myPlayer.SoundLocation = @"C:\ElevenFiftyProjects\SDLessons69\HangManGame\Tada-sound.wav";
            myPlayer.Play();
          
        } 

        public void LoserSound() // method: it plays sound when you lose
        {
            var myPlayer = new SoundPlayer();
            myPlayer.SoundLocation = @"C:\ElevenFiftyProjects\SDLessons69\HangManGame\screamandchoke.wav";
            myPlayer.Play();
        }

    }
}
