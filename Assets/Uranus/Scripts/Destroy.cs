/*
 * This script listens for trigger events with other colliders. 
 * When a trigger event is detected, the script checks the tag of the other collider. 
 * If the other collider has the tag "Uranus", the script will deactivate the current game object, store its position, and 
 * instantiate an explosion prefab at the stored position. If the other collider has the tag "NoiseTarget" or "laser", 
 * the script will deactivate the current game object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private Vector3 colPos; //a Vector3 for storing the position of each collision between Uranus and an asteroid
    [SerializeField] private GameObject explosionPrefab; //reference to the explosionPrefab gameobject


    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the "Uranus" tag and if so, deactivate the current object, store its position and instantiate the explosion prefab at the stored position
        if (other.gameObject.CompareTag("Uranus"))
        {
            gameObject.SetActive(false);
            colPos = gameObject.transform.position;
            Instantiate(explosionPrefab, colPos, Quaternion.identity);
        }

        // Check if the other object has the "NoiseTarget" tag and if so, deactivate the current object
        if (other.gameObject.CompareTag("NoiseTarget"))
        {
            gameObject.SetActive(false);
        }

        // Check if the other object has the "laser" tag and if so, deactivate the current object
        if (other.gameObject.CompareTag("laser"))
        {
            gameObject.SetActive(false);
        }

    }

}
