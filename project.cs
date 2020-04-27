using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class HangMan : MonoBehaviour
{
     public Text messageText;
     public InputField guessInput;
     public Text systemMessage;
     public string wordtoGuess; // correct answer
     public string hiddenWord;  // answer submitted by player, will update one by one per input
     //Player chance can change
     public int playerLives = 10;
     public Text livesWindow;
     public Text showWords;
     public Text wordsHint;
     public Button submitButton;
     public Text wordsWrongShow;
     public Text inputWrongChar;
     public List<char> wrongChar= new List<char>();

     //Words used (can put in more)
     string[] dictionary = 
        {
            "chair",
            "table",
            "bench",
            "spoon",
            "choir",
            "mouse",
            "phone",
            "money"
        };

    //Random generate words
    void wordsArray()
    {
        // Get random word
       System.Random random = new System.Random();
       int index = random.Next(dictionary.Length);
       string wordPicked = dictionary[index];
       
       char[] chars = wordPicked.ToCharArray();
       for (int i=0; i<chars.Length; i++)
       {
           chars[i] = '_';
       }

        string wordLastPick = new string (chars);
        
        // string hintWords = wordsHint.text;
        wordsHint.text = "Word Length: " + wordLastPick.Length;
    
        hiddenWord = wordLastPick;
        wordtoGuess = wordPicked;
    }


    //Print words to guess
    void wordsShows()
    {
        string plWords = showWords.text;
        showWords.text = hiddenWord; // the display will get from hiddenWord variable
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
        string guessString = guessInput.text.ToLower(); // player input
        string hiddenString = showWords.text; // player result, started wit '______'
        showWords.text = hiddenWord;
        char inputChar = guessString.ToCharArray()[0];
        char[] charGuess = hiddenString.ToCharArray();
        char[] correctAnswer = wordtoGuess.ToCharArray(); // get correct answer
        bool isInputCorrect = false;
        if (playerLives>0)
        {
            for(int i = 0; i < correctAnswer.Length; i++)
            {   
                if(correctAnswer[i] == inputChar)
                {
                    charGuess[i] = inputChar; 
                    isInputCorrect = true;
                }
            }

            if(isInputCorrect)
            {
                hiddenWord = new string(charGuess); 
                // update back to hidden word
                // because you didnt update back the word
                // so after the input is correct, need to update back the word lo
            }
            else 
            {
                systemMessage.text = "Wrong input, try again";
                string plWrong = inputWrongChar.text;
                inputWrongChar.text += inputChar + ", ";
                playerLives--;
               
            }
        }

        if (playerLives <=0)
        {
           systemMessage.text = "Game Over\n\nThe words is " + wordtoGuess + "\n\nTry hard next time";
            GameOver();
        }

    }

    void nextLevel()
    {
        if (wordtoGuess==hiddenWord && playerLives>0)
        {
            systemMessage.text = "Correct\n\nThe answer is " + wordtoGuess;
            playerLives = 10;
            inputWrongChar.text = " ";
            wordsArray();
        }
    }

    //Destroy buttons and text object
    void GameOver()
    {
        guessInput.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
        wordsHint.gameObject.SetActive(false);
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
       nextLevel();
       Lives();
       wordsWrong();
    }
}
