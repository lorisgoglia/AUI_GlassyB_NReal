/*
 *This script uses a public float variable "timeValue" to set the total time for the game, and displays the remaining time on the screen using 
 *a Text component "timerText". A countdown before the game starts is also displayed using another Text component "countdown", 
 *and the "GO" signal is displayed using a Text component "goText". The script also includes functionality for pausing and restarting the game, 
 *managing a screen for gameover, one for win and oneother for the pause.
 *It uses IEnumerators and several boolean variables to control the flow of the timer and different game states.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//class UranusTimer is used to create a timer in the game and display it on the screen
public class UranusTimer : MonoBehaviour
{
    //timeValue is the total time the player has to complete the game
    public float timeValue = 60;
    //timerText is the Text component used to display the time on the screen
    public Text timerText;
    //countdown is the Text component used to display the countdown before the game starts
    public Text countdown;
    //goText is the Text component used to display "GO" when the countdown ends
    public Text goText;
    //timeStart is the time for the countdown before the game starts
    public float timeStart = 4;
    //menu is the GameObject that contains the menu to quit or restart the game when the time is over
    public GameObject menu;
    //timeOver is the GameObject that appears when the time is over
    public GameObject timeOver;
    //pauseGame is the GameObject that appears when the game is paused
    public GameObject pauseGame;
    //win is the GameObject that appears when the player wins the game
    public GameObject win;
    //tempTime is used to save the timeValue when the game is paused
    public float tempTime = 0;
    //pause is a boolean used to check if the game is paused or not
    public bool pause = false;
    //restart is a boolean used to check if the player wants to restart the game or not
    public bool restart = false;
    //stopGameOver is a boolean used to stop the time when the timeOver panel is active
    public bool stopGameOver = false;
    //A reference to UranusGameManager script
    UranusGameManager uranusGameManager;
    //A reference to gameManager object
    [SerializeField] private GameObject gameManager;

    IEnumerator TimeGoText()
    {
        //Enables the goText object
        goText.enabled = true;
        //Waits for 1 second before disabling the goText object
        yield return new WaitForSeconds(1);

        goText.enabled = false;


    }

    IEnumerator FixRestart()
    {
        // Stops the game over process
        stopGameOver = true;

        // Waits for 1 second before setting stopGameOver to false
        yield return new WaitForSeconds(1);
        stopGameOver = false;
    }

    private void Start()
    {
        // Disables the menu and pauseGame objects at the start of the game
        menu.SetActive(false);
        pauseGame.SetActive(false);
        uranusGameManager = gameManager.GetComponent<UranusGameManager>();
    }


    void Update()
    {
        // Calls the Countdown() and IsGameOver() methods
        Countdown();
        IsGameOver();
    }

    void DisplayTime(float timeToDisplay)
    {
        // Resets the time to 0 if it's negative to prevent a glitch
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // Calculates the minutes and seconds remaining
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formats the time display as "mm:ss"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Opens the win menu and disables the timeOver and pauseGame objects, in case of victory
    void OpenMenu()
    {
        menu.SetActive(true);
        timeOver.SetActive(false);
        pauseGame.SetActive(false);
        win.SetActive(true);
    }

    // Stops the timer if the timeOver object is active and the user does not wants to exit the menu
    void IsGameOver()
    {
        if ((timeOver.activeInHierarchy == true || uranusGameManager.threeSecOver == true) && stopGameOver == false)
        {
            timeValue = 99999; //99999 is just a random big value to manage gameOver particular case
        }
    }

    // Restarts the time when the restart button is pressed on the menu
    public void Restart(bool restart)
    {
        if (restart == true)
        {
            //start the FixRestart() coroutine
            StartCoroutine(FixRestart());
            timeStart = 4;
            timeValue = 47;
            countdown.enabled = true;
            Countdown();
        }

    }


    //countdown at the beginning of the game
    void Countdown()
    {
        // Check if the timeStart is greater than 1
        if (timeStart > 1)
        {
            // Decrement timeStart by Time.deltaTime
            timeStart -= Time.deltaTime;
            // Check if the timeStart is less than 1
            if (timeStart < 1)
            {
                // Set timeStart to 1
                timeStart = 1;
            }
            // Get the seconds by flooring the timeStart
            float seconds = Mathf.FloorToInt(timeStart);
            // Set the countdown text to the seconds value formatted to show only one digit
            countdown.text = string.Format("{0:0}", seconds); //printing the countdown
                                                              // Call the DisplayTime function with the timeValue
            DisplayTime(timeValue); //printing the time remaining that stay always the same because the game isn't started yet
                                    // Disable the goText
            goText.enabled = false;
        }
        // Check if the timeStart is equal to 1
        else if (timeStart == 1)
        {
            // Check if the countdown is enabled
            if (countdown.enabled == true)
            {
                // Disable the countdown
                countdown.enabled = false;
                // Start the TimeGoText coroutine
                StartCoroutine(TimeGoText());
            }
            // Call the FlowingTime function
            FlowingTime();
        }
    }


    //Timer start to be decremented once the countdown ends
    void FlowingTime()
    {
        // Check if the timeValue is greater than 0 and less than 9999
        if (timeValue > 0 && timeValue < 9999)
        {
            // Check if the pauseGame is not active in hierarchy
            if (pauseGame.activeInHierarchy == false)
            {
                // Decrement the timeValue by Time.deltaTime
                timeValue -= Time.deltaTime;
                // Assign the tempTime variable to the current timeValue
                tempTime = timeValue;
            }
            else
            {
                // Assign the timeValue to the tempTime variable
                timeValue = tempTime;
            }
        }
        // Check if the timeValue is greater than 9999
        else if (timeValue > 9999)
        {
            // Assign the timeValue to the tempTime variable
            timeValue = tempTime;
        }
        else
        {
            // Set the timeValue to 0
            timeValue = 0;
            // Call the OpenMenu function
            OpenMenu();
        }
        // Call the DisplayTime function with the timeValue
        DisplayTime(timeValue);
    }


}
