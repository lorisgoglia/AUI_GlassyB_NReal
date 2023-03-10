using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.rotation = target.rotation;
    }

    public void resetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
