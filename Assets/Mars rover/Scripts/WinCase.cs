using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WinCase : MonoBehaviour
{

    public int total = 12;
    public Text aliensFound;
    private string numFound;
    private int found = 0;
    public GameObject menu;
    public GameObject rover;
    public GameObject ground;
    public GameObject menuWin;
    public GameObject menuTimeOver;
    public GameObject menuPause;
    public GameObject alien;
    public GameObject alien2;
    public GameObject menuCanvas;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        numFound = aliensFound.text;
        found = Int32.Parse(numFound);
       

        if(found == total)
        {
            ground.SetActive(false);
            alien.SetActive(false);
            alien2.SetActive(false);
            var clones = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(false);
            }
            menuCanvas.SetActive(false);
            menu.SetActive(true);
            rover.SetActive(false);
            menuPause.SetActive(false);
            menuTimeOver.SetActive(false);
            menuWin.SetActive(true);
        }
        
    }
}
