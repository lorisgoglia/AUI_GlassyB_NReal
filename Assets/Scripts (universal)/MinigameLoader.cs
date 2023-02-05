using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameLoader : MonoBehaviour
{
    public GameObject sunnyScene;
    public GameObject uranusScene;
    public GameObject marsScene;
    public GameObject uranusTutorialScene;
    public GameObject marsTutorialScene;

    public FollowCamera followScript;
    public GameObject camera;
    public Animator animator;
    public CollectedPlanets collectedPlanets;


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
    }

    public void sunnyToMarsTutorial()
    {
        //animator.SetBool("IsIn", false);
        sunnyScene.SetActive(false);
        marsTutorialScene.SetActive(true);
        marsTutorialScene.GetComponent<BeginTutorial>().enabled = true;
    }

    public void TutorialToMars()
    {

        marsTutorialScene.SetActive(false);
        marsScene.SetActive(true);
        //aggiungere codice per spostare camera come figlio del rover
        //followScript.enabled = true;
        resetPosition();


        //object1 is now the child of object2
    }

    public void MarsToSunny()
    {
        camera.transform.parent = null;
        marsScene.SetActive(false);
        sunnyScene.SetActive(true);
        //aggiungere codice per spostare camera in (0,0,0)
        //followScript.resetPosition();
        //followScript.enabled = false;
        resetPosition();

    }

    private void resetPosition()
    {
        camera.transform.position = new Vector3(0, 0, 0);
    }



}
