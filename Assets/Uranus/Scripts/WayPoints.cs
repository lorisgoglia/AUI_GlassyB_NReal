/*
 * This script controls the movement of an object along a set of waypoints. 
 * It initializes an array of waypoints in the Start method and in the Update method, 
 * it checks if the object's distance from the current waypoint is less than a set radius. 
 * If so, it increments the current waypoint, and if the current waypoint is the last in the array, 
 * it sets it back to the first one. It then moves the object towards the current waypoint at a set speed, creating a loop.
 */

using UnityEngine;

public class WayPoints : MonoBehaviour
{
    // array of waypoints
    private Vector3[] wayPoints = new Vector3[4];
    // current waypoint
    private int current = 0;
    // speed of the object
    [SerializeField] private float speed;
    // radius of the waypoint
    private float WPradius = 0.1f;

    private void Start()
    {
        // setting the positions of the waypoints
        wayPoints[0] = new Vector3(3, -1, 2.5f);
        wayPoints[1] = new Vector3(2, -1, 4);
        wayPoints[2] = new Vector3(-2, -1, 2.5f);
        wayPoints[3] = new Vector3(-3, -1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // check if the distance between current waypoint and object position is less than the waypoint radius
        if (Vector3.Distance(wayPoints[current], transform.position) < WPradius)
        {
            current++;
            // if current waypoint is at the end of the waypoints array, set current back to 0
            if (current >= wayPoints.Length)
            {
                current = 0;
            }
        }
        // move the object towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[current], Time.deltaTime * speed);
    }

}
