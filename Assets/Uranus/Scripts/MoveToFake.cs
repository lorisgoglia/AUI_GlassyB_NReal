/*
 * This script moves an object towards a "fake Uranus" object (called "NoiseTarget") at a given speed and rotation speed. 
 * The script also references a "UranusLife" script, and will only move the object if the "isPause" variable of the "UranusLife" script is set to false. 
 * The script finds the "NoiseTarget" and "Uranus" objects in the scene during the Start() method, 
 * and then updates the object's position and rotation during the Update() method.
 */

using UnityEngine;

public class MoveToFake : MonoBehaviour
{
    private Vector3 urPos; //Vector3 to store the position of the noise target, the "fake Uranus"
    public float speed = 5; //movement speed of the object
    public float rotSpeed = 5; //rotation speed of the object
    UranusLife uranusLife; // Reference to UranusLife script

    private void Start()
    {
        //find the "NoiseTarget" object and set it as the position to move towards
        if (GameObject.Find("NoiseTarget") != null)
        {
            urPos = GameObject.Find("NoiseTarget").transform.position;
        }
        //find the "Uranus" object and get the "UranusLife" script component
        if (GameObject.Find("Uranus") != null)
        {
            uranusLife = GameObject.Find("Uranus").GetComponent<UranusLife>();
        }
    }

    void Update()
    {
        //if "NoiseTarget" object is not null and the "UranusLife" script's "isPause" variable is false
        if (GameObject.Find("NoiseTarget") != null && uranusLife.isPause == false)
        {
            //move the object towards "urPos" at a certain speed
            transform.position = Vector3.MoveTowards(transform.position, urPos, Time.deltaTime * speed);
            //rotate the object around its up axis at a speed of "rotSpeed"
            transform.RotateAround(transform.position, transform.up, rotSpeed * Time.deltaTime);
        }
    }



}
