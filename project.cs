using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Linq;

public class HangMan : MonoBehaviour
{
     public Text messageText;
     public InputField guessInput;
     public Text systemMessage;
     public string wordtoGuess;
     public string hiddenWord;
     //Player chance can change
     public int playerLives = 10;
     public Text livesWindow;
     public Text showWords;
     public Text wordsHint;
     public Button submitButton;
     public Text wordsWrongShow;


     
     //Words used (can put in more)
     string[] wordUsed = 
        {
            "Chair",
            "Table",
            "Bench",
            "Spoon",
            "Choir",
            "Mouse",
            "Phone",
            "Money"
        };
    //Random generate words
    void wordsArray()
    {
       System.Random random = new System.Random();
       int wordChoose = random.Next(wordUsed.Length);
       string wordPick = wordUsed[wordChoose];
       
       char[] chars = wordPick.ToCharArray();
       for (int i=0; i<chars.Length; i++)
       {
           chars[i] = '_';
       }

        string wordLastPick = new string (chars);
        
        string hintWords = wordsHint.text;
        wordsHint.text = "Word Length: " + wordLastPick.Length;
    

        char letter = guessInput.text.ToCharArray()[0];
        for (int i=0; i<wordPick.Length; i++)
        {
            if (wordPick[i] == letter)
                chars[i] = letter;
        }

        hiddenWord = wordLastPick;
        wordtoGuess = wordPick;
    }


    //Print words to guess
    void wordsShows()
    {
        string plWords = showWords.text;
        showWords.text = hiddenWord;
    }

    //Print wrong words
    void wordsWrong()
    {
        string plWrong = wordsWrongShow.text;
        wordsWrongShow.text = "Wrong Letter: ";
        if(playerLives <= 0)
        {
            wordsWrongShow.gameObject.SetActive(false);
        }
    }

    //Print chance left
    void Lives()
    {
        string plLives = livesWindow.text;
        livesWindow.text = "Chance:" + playerLives;
        if(playerLives <= 0)
        {
            livesWindow.gameObject.SetActive(false);
        }
    }

    //Message indicate player guess right or wrong
    public void GetGuess()
    {
        string guessString = guessInput.text;
        if (playerLives>0)
        {
            if (guessString == wordtoGuess)
        {
            systemMessage.text = "You Guess it right";
            playerLives =11 ;
        }
        else 
            systemMessage.text = "Try again";
            playerLives--;
        }
        

        if (playerLives <= 0)
        {
            systemMessage.text = "Game Over\n\nThe words is " + wordtoGuess + "\n\nTry hard next time";
            GameOver();
        }

    }

    //Destroy buttons and text object
    void GameOver()
    {
        guessInput.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
       wordsArray();

    }

    // Update is called once per frame
    void Update()
    {
       wordsShows();
       Lives();
       wordsWrong();
    }
}
