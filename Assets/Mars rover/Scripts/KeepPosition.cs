using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPosition : MonoBehaviour
{
    public GameObject camera;
    

    //Method to keep the canvas in the same position of the camera but shifted in front of 0.5, used to make the canvas follow the camera
    void Update()
    {
        transform.position = camera.transform.position + new Vector3(0.0f, 0.0f, 0.5f);
       
    }

    
}
