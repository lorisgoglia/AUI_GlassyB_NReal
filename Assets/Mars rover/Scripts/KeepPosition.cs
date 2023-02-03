using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPosition : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(0.0f, 2.0f, 1.0f);
        transform.position = camera.transform.position + new Vector3(0.0f, -(0.005f), 0.3f);
       
    }
}
