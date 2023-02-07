using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour
{
    public bool stop = false;

    //if the rover meet a rock or the border of the game is bounced back
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Barrier"))
        {
            stop = true;
        }
        
    }
}
