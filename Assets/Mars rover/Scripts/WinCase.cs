using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WinCase : MonoBehaviour
{

    public int total = 20;
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


    // Start is called before the first frame update
    void Start()
    {
        numFound = aliensFound.text;
        found = Int32.Parse(numFound);
    }

    // Update is called once per frame
    void Update()
    {
        if(found == total)
        {
            rover.GetComponent<MeshRenderer>().enabled = false;
            ground.SetActive(false);
            alien.SetActive(false);
            var clones = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                //Destroy(clone);
                clone.SetActive(false);
            }
            menu.SetActive(true);
            //menu.transform.position = new Vector3(0.0f, 2.0f, 1.0f);
            menuPause.SetActive(false);
            menuTimeOver.SetActive(false);
            menuWin.SetActive(true);
        }
        
    }
}
