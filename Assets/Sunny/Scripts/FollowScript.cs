using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 sunnyDistance = new Vector3(8, 2, 0);
    private Vector3 currentOffset;

    void Update()
    {
        currentOffset = transform.position - target.transform.position;
        if (sunnyDistance.magnitude < currentOffset.magnitude)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + sunnyDistance, Time.deltaTime * 4);
            transform.LookAt(target);

        }


    }

}
