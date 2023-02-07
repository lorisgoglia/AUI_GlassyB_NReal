using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to keep the two tipes of alien awake when needed, used to solve a problem caused by the disactivation of the gameObject 
public class Active : MonoBehaviour
{
    public GameObject alienPink;
    public GameObject alienGreen;

    // Update is called once per frame
    void Update()
    {
        alienPink.SetActive(true);
        alienGreen.SetActive(true);
    }
}
