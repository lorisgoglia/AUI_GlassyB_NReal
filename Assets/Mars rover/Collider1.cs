using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour
{
    public bool stop = false;

    void Start()
    {

    }
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Barrier"))
        {
            stop = true;
        }
        
    }
}
