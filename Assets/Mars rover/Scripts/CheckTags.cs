using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTags : MonoBehaviour
{
    public int alienCounter = 0;
   //public Text alienCounterText;
    public GameObject aliensPrefab;

    //How to check if there are aliens in my screenshot and update the counter of aliens
    void Start()
    {

        //aliensPrefab = GameObject.FindGameObjectsWithTag("Alien");
        Debug.Log(aliensPrefab.name);
        //alienCounterText.text = string.Format("0", alienCounter);
        alienCounter++;
        aliensPrefab.SetActive(false);
    
        /*if(gameObject.tag == "Alien")
        {
            alienCounterText.text = string.Format("0", alienCounter);
            alienCounter++;
            this.gameObject.SetActive(false);
        }*/
        
    }
}

