using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetRotationNew()
    {
        transform.rotation = new Quaternion(0f,0f,0f,0f);
    }
}
