using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class HangMan : MonoBehaviour
{
    string[] words;

    public int Lives = 10; 
    private string wordsInput = "";
    private string wordsGuess = "";
    private string wordsShows = "";

    void wordsInput ()
    {
        words = new int [5];
        words[0] = chair;
        words[1] = table;
        words[2] = bench;
        words[3] = spoon;
        words[4] = choir;
        
    }

    
    
    private void OnScreen ()
    {   
        string secretWords = wordsInput[0];

        int secretWords = secretWords.Length;
        Console.Write("Your secret word is:");
        for (int i=0; i<secretWords; i++)
                Console.Write("*");
            Console.Write();


        while (true)
        {
           for (int i = 0; i < wordsShows.Length; i++) 
            {
                if (i < secretWord.Length && i < choice.Length)
                {
                    if (wordsInput[i] == words[i])
                    Console.Write(words[i]);
                    else
                    Console.Write("*");
                }
                else 
                Console.Write("*");
            }
            Console.WriteLine();
        }


        {
          if (Lives >0 )
           {
              Console.write("Try Again");
           }
          else
          {
             chanceGuess = true;

         }

         if (chanceGuess = true)
         {
             Console.Write("You lose");
         }
         else
            {
                Console.Write("Correct Answer");
            }
        }
    }

}
