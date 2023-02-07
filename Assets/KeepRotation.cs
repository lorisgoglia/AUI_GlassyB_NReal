using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    public GameObject camera;
    
    //method to keep the rotation of the area check following the rotation of the camera
    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        
    }
}
