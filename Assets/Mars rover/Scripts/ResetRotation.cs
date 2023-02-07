using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{
    //method to reset the rotation of the rover when I restart the game 
    public void ResetRotationNew()
    {
        transform.rotation = new Quaternion(0f,0f,0f,0f);
    }
}
