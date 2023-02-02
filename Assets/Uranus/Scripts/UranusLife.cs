/*
 * This script has variables for current and maximum health of Uranus, a prefab for an explosion when Uranus is destroyed, 
 * a prefab for a pause menu, and a boolean for checking if the game is paused. 
 * The Update function checks the current health of Uranus, calls a Die function and creates an explosion when the health reaches zero, 
 * checks if the pause menu is active, and sets the current health to the max health if it goes in gameover. 
 * The OnTriggerEnter function decreases the current health by one and plays a sound when it collides with an object tagged as an asteroid. 
 * There is also a public function called HealthOnRestart that sets the current health to the max health on restart.
 */

using UnityEngine;

public class UranusLife : MonoBehaviour
{

    public int currentHealth = 6; // current health of Uranus
    public int maxHealth = 6; // maximum health of Uranus
    [SerializeField] private GameObject explosionPrefab; // prefab for the explosion when Uranus is destroyed
    [SerializeField] private GameObject pausePrefab; // prefab for the pause menu
    public bool isPause = false; // boolean to check if the game is paused

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // sets current health to max health if it goes over
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // calls the Die function
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity); // creates an explosion at the current position of Uranus
        }

        if (pausePrefab.activeInHierarchy == true) isPause = true; // checks if the pause menu is active
        else isPause = false;

    }

    void Die()
    {
        gameObject.SetActive(false); // deactivates the Uranus game object
        SoundManagerScript.PlaySound("UranusExplosion"); // plays the sound for Uranus's explosion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            currentHealth--; // decreases current health by 1
            SoundManagerScript.PlaySound("impact"); // plays the sound for impact
        }
    }

    public void HealthOnRestart()
    {
        currentHealth = maxHealth; // sets current health to max health on restart
    }

}
