using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        if (Lives >0 )
        {
            
        }
        else
        {
            print ("Game Over");

        }
    }


    private void wordsCheck(char c)
    {
        for (int i = 0; i < wordsShows.Length; i++) ;
        {

        }
    }


}
