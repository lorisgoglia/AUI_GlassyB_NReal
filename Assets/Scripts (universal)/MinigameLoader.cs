using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameLoader : MonoBehaviour
{
    public GameObject sunnyScene;
    public GameObject uranusScene;
    public GameObject marsScene;
    public GameObject uranusTutorialScene;
    public GameObject marsTutorialScene;
    public GameObject menuCanvas;
    public GameObject roverView;
    public GameObject menu;
    public int start = 0;
    public GameObject ground;
    public GameObject game;
    public GameObject rover;
    public GameObject alienSpawner;
    public GameObject alienSpawner2;
    public Text aliensFound;
    public Text aliensFound1;
    public Text planetsWon;
    public Text planetsWon1;
    public Timer time;
    public MovementRover move;
    public ResetRotation reset;
    public Spawneralien spawn;
    public Spawneralien spawn2;
    public GameObject alienPink;
    public GameObject alienGreen;

    public FollowCamera followScript;
    public GameObject camera;
    public Animator animator;
    public CollectedPlanets collectedPlanets;

    public EndGame endGame;


    private void Start()
    {
    }


    public void SunnyToUranusTutorial()
    {
        animator.SetBool("IsIn", false);
        sunnyScene.SetActive(false);
        uranusTutorialScene.SetActive(true);
        uranusTutorialScene.GetComponent<BeginTutorial>().enabled = true;
    }

    public void TutorialToUranus()
    {
        uranusTutorialScene.SetActive(false);
        uranusScene.SetActive(true);
    }

    public void UranusToSunny()
    {
        uranusScene.SetActive(false);
        collectedPlanets.updatePlanets();
        sunnyScene.SetActive(true);
        endGame.isUranusFinished = true;
    }

    public void sunnyToMarsTutorial()
    {
        //animator.SetBool("IsIn", false);
        sunnyScene.SetActive(false);
        marsTutorialScene.SetActive(true);
        marsTutorialScene.GetComponent<BeginTutorial>().enabled = true;
    }

    public void TutorialToMars() //restart scenario tutorial mars
    {

        marsTutorialScene.SetActive(false);
        marsScene.SetActive(true);
        ground.transform.position = new Vector3(-500.0f, -2.44f, -555.04f);
        ground.SetActive(true);
        game.SetActive(true);
        rover.SetActive(true);
        menuCanvas.SetActive(true);
        roverView.SetActive(true);
        alienPink.SetActive(true);
        alienGreen.SetActive(true);
        alienSpawner.SetActive(true);
        alienSpawner2.SetActive(true);
        reset.ResetRotationNew();
        spawn.spawnAliensAgain();
        spawn2.spawnAliensAgain();
        time.Restart(true);
        aliensFound.text = start.ToString();
        aliensFound1.text = start.ToString();
        planetsWon.text = start.ToString();
        planetsWon1.text = start.ToString();
       

        //aggiungere codice per spostare camera come figlio del rover
        //followScript.enabled = true;
        resetPosition();
    }

    public void MarsToSunny() //move back to sunny when I do quit on mars
    {
        camera.transform.parent = null;
        marsScene.SetActive(false);
        sunnyScene.SetActive(true);
        menuCanvas.SetActive(false);
        roverView.SetActive(false);
        menu.SetActive(false);
        collectedPlanets.updatePlanets();

        //aggiungere codice per spostare camera in (0,0,0)
        //followScript.resetPosition();
        //followScript.enabled = false;

        if (collectedPlanets.collected == 8)
            endGame.isGameWon = true;
        else
            endGame.isGameLost = true;
        resetPosition();

    }

    private void resetPosition()
    {
        camera.transform.position = new Vector3(0, 0, 0);
    }



}
