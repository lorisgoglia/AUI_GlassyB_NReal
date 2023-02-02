using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeValue = 181;
    public Text timerText;
    public Text countdown;
    public Text goText;
    public float timeStart = 4;
    public GameObject menu;
    public GameObject timeOver;
    public GameObject pauseGame;
    public GameObject win;
    public float tempTime = 0;
    public bool pause = false;
    public bool restart = false;
    public GameObject marsMenu;
    public GameObject game;
    public GameObject alien;


    //I want to enable and disenable the "GO!" text at the beginning of the game, after 1 second
    IEnumerator TimeGoText()
    {
        
            goText.enabled = true;
            //yield on a new YieldInstruction that waits for 1 seconds.
            yield return new WaitForSeconds(1);

            goText.enabled = false;
        
        
    }


    void Start()
    {
        menu.SetActive(false);
        pauseGame.SetActive(false);
       
    }

    //here I check if the "time remaining" called time value is ended or not, if it's not ended I decrement it otherwise I keep it at 0 
    //timeStart is the countdown at the beginning of the game
    void Update()
    {
        Countdown();
    }


    //here I'm setting what time and how the time have to be seen on the display, if the last value findend it's negative, I'll reset it at zero, to prevent the glitch, otherwise I calculate the minutes and seconds left
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //where "{0 --> the first element nominated = minutes : 00 --> in the format of two digits}:{1 --> the second element = seconds : 00 --> the format}" 

    }


    //Open only the game over panel with the menu to quit the game or restart
    void OpenMenu()
    {
        menu.SetActive(true);
        timeOver.SetActive(true);
        pauseGame.SetActive(false);
        win.SetActive(false);
        marsMenu.SetActive(false);
        game.SetActive(false);
        alien.SetActive(false);
        
    }


   //Stop time when in pause, so timeValue keep the last saved value in tempTime
    public void Pause(bool pause)
    {
        if(pause == true)
        {
            timeValue = tempTime;
            var clones = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(false);
            }
            pause = false;
        
        }else
        {
            var clones = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(true);
            }
        }
       
    }


    //Restart time when click on restart on the menu
    public void Restart(bool restart)
    {
        if(restart == true)
        {
            timeStart = 4;
            timeValue = 60;
            countdown.enabled = true;
            Countdown();
            restart = false;
        }
       
    }


    //countdown at the beginning of the game
    void Countdown()
    {
        if(timeStart > 1)
        {
            timeStart -= Time.deltaTime;
            if(timeStart < 1)
            {
                timeStart = 1;
            }
            float seconds = Mathf.FloorToInt(timeStart);
            countdown.text = string.Format("{0:0}", seconds); //printing the countdown
            DisplayTime(timeValue); //printing the time remaining that stay always the same because the game isn't started yet
            goText.enabled = false;
        }
        
        else if(timeStart == 1)
        {
            if(countdown.enabled == true)
            {
                countdown.enabled = false;
                StartCoroutine(TimeGoText());
            }
            FlowingTime();

        }
    }


    //Timer start to be decremented once the countdown ends
    void FlowingTime()
    {
        if(timeValue > 0) //now I can start decrementing the time remaining checking if I'm in pause or not 
        {
                
            Pause(pause);
            timeValue -= Time.deltaTime;
            tempTime = timeValue;

        }
        else
        {
            timeValue = 0;
            OpenMenu();
            var clones = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(false);
            }
        }

        DisplayTime(timeValue);
    }
    
}
