/*
 * This script moves an object towards Uranus and rotates it around its up axis at a certain speed. 
 * The script also checks if the "Uranus" object is not null and if the "UranusLife" script's "isPause" variable is false before moving and rotating 
 * the object.
 */

using UnityEngine;

public class MoveToUranus : MonoBehaviour
{
    private Vector3 urPos; //Vector3 to store the position of Uranus
    public float speed = 5; //movement speed of the object
    public float rotSpeed = 5; //rotation speed of the object
    UranusLife uranusLife; // Reference to UranusLife script

    private void Start()
    {
        //find the "Uranus" object and set it as the position to move towards
        if (GameObject.Find("Uranus") != null)
        {
            urPos = GameObject.Find("Uranus").transform.position;
            //get the "UranusLife" script component
            uranusLife = GameObject.Find("Uranus").GetComponent<UranusLife>();
        }

    }

    void Update()
    {
        //if "Uranus" object is not null and the "UranusLife" script's "isPause" variable is false
        if (GameObject.Find("Uranus") != null && uranusLife.isPause == false)
        {
            //move the object towards "urPos" at a certain speed
            transform.position = Vector3.MoveTowards(transform.position, urPos, Time.deltaTime * speed);
            //rotate the object around its up axis at a speed of "rotSpeed"
            transform.RotateAround(transform.position, transform.up, rotSpeed * Time.deltaTime);
        }
    }


}
