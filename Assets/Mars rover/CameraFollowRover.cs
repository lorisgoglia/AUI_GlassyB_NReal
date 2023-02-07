using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRover : MonoBehaviour
{

    public GameObject rover;
    public GameObject camera;
    public GameObject userView;
    
    public GameObject roverView;

    // Start is called before the first frame update
    void Update()
    {
        userView.transform.parent = camera.transform;
        roverView.transform.parent = camera.transform;
        camera.transform.parent = rover.transform;
        
    }

}
