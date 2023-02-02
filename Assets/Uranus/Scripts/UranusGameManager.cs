/*
 * This script is the very core of Uranus minigame and manages almost all the logic throughout all the stages of the minigame.
 */

using System.Collections;
using UnityEngine;

public class UranusGameManager : MonoBehaviour
{
    UranusLife uranusLife; // Reference to the UranusLife script component on the Uranus object
    BeamGestures beamGestures; // Reference to the BeamGestures script component on this object
    SpawnAsteroids spawnAsteroids; // Reference to the SpawnAsteroids script component on the spawner object
    SpawnAsteroids spawnAsteroids2; // Reference to the SpawnAsteroids script component on the spawner2 object
    SpawnAsteroids spawnAsteroids3; // Reference to the SpawnAsteroids script component on the spawner3 object
    SpawnAsteroids spawnFake; // Reference to the SpawnAsteroids script component on the FakeSpawner object
    SpawnAsteroids spawnFake2; // Reference to the SpawnAsteroids script component on the FakeSpawner2 object
    [SerializeField] private GameObject spawner; // Reference to the spawner object
    [SerializeField] private GameObject spawner2; // Reference to the spawner2 object
    [SerializeField] private GameObject spawner3; // Reference to the spawner3 object
    [SerializeField] private GameObject FakeSpawner; // Reference to the FakeSpawner object
    [SerializeField] private GameObject FakeSpawner2; // Reference to the FakeSpawner2 object
    [SerializeField] private GameObject uranus; // Reference to the Uranus object
    [SerializeField] private GameObject winPrefab; // Reference to the winPrefab object
    [SerializeField] private GameObject menu; // Reference to the menu object
    [SerializeField] private GameObject gameOverPrefab; // Reference to the gameOverPrefab object
    [SerializeField] private GameObject pausePrefab; //Reference to the pausePrefab object
    public bool threeSecOver = false; // variable to check if 3 seconds have passed since game over
    public bool PauseFinish = false; // variable to check if the pause is finished
    private bool overDone = false; // variable to check if game over sequence has been executed

    IEnumerator GameOver()
    {
        threeSecOver = true; //if threeSecOver is true the timer will stop immediately
        yield return new WaitForSeconds(3);
        menu.SetActive(true); // activate the menu
        winPrefab.SetActive(false); // deactivate the win prefab
        gameOverPrefab.SetActive(true); // activate the game over prefab
        pausePrefab.SetActive(false); // deactivate the pause prefab
        uranusLife.currentHealth = uranusLife.maxHealth; // reset the health of Uranus
        overDone = false; // set overDone to false
    }

    private void Awake()
    {
        uranusLife = uranus.GetComponent<UranusLife>(); // get the UranusLife component
        spawnAsteroids = spawner.GetComponent<SpawnAsteroids>(); // get the SpawnAsteroids component
        spawnAsteroids2 = spawner2.GetComponent<SpawnAsteroids>(); // get the SpawnAsteroids component
        spawnAsteroids3 = spawner3.GetComponent<SpawnAsteroids>(); // get the SpawnAsteroids component
        spawnFake = FakeSpawner.GetComponent<SpawnAsteroids>(); // get the SpawnAsteroids component
        spawnFake2 = FakeSpawner2.GetComponent<SpawnAsteroids>(); // get the SpawnAsteroids component
        beamGestures = gameObject.GetComponent<BeamGestures>(); // get the BeamGestures component
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAsteroids(); // call the function to destroy the asteroids
        DestroySpawners(); // call the function to destroy the spawners
        IsGameOver(); // check if game over
        IsPause(PauseFinish); // check if pause menu is finished
        pauseOnDeath(); // check if game should be paused on death
    }

    public void DestroyAsteroids()
    {
        if ((uranusLife.currentHealth == 0) || winPrefab.activeInHierarchy == true) // if Uranus health is 0 or win prefab is active
        {
            var clones = GameObject.FindGameObjectsWithTag("Asteroid"); // find all objects with the "Asteroid" tag
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                clone.SetActive(false); // deactivate the asteroid
            }
        }
    }

    //Method to destroy asteroid spawners when the game is over or the player wins
    public void DestroySpawners()
    {
        //Check if the game is over or the player has won
        if ((uranusLife.currentHealth == 0) || winPrefab.activeInHierarchy == true)
        {
            //Find all objects with the tag "AsteroidSpawner"
            var clones = GameObject.FindGameObjectsWithTag("AsteroidSpawner");
            //Loop through each object and deactivate it
            for (int i = 0; i < clones.Length; i++)
            {
                GameObject clone = clones[i];
                clone.SetActive(false);
            }
        }
    }

    //Method to check if the game is over
    public void IsGameOver()
    {
        //Check if the player's health is 0 and if the game over sequence hasn't been triggered yet
        if (uranusLife.currentHealth == 0 && overDone == false)
        {
            overDone = true;
            //Start the game over sequence
            StartCoroutine(GameOver());
        }
    }

    //Method to handle pausing and unpausing the game
    public void IsPause(bool PauseFinish)
    {
        //If the pause menu is active
        if (pausePrefab.activeInHierarchy == true)
        {
            PauseFinish = false;
            //Deactivate the asteroid spawners, laser and fake asteroid spawners
            spawner.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
            FakeSpawner.SetActive(false);
            FakeSpawner2.SetActive(false);

        }
        //If the game is being unpaused
        if (PauseFinish == true)
        {
            //Reactivate the asteroid spawners, laser and fake asteroid spawners
            spawner.SetActive(true);
            spawner2.SetActive(true);
            spawner3.SetActive(true);
            spawnAsteroids.SpawnAgain();
            spawnAsteroids2.SpawnAgain();
            spawnAsteroids3.SpawnAgain();
            FakeSpawner.SetActive(true);
            FakeSpawner2.SetActive(true);
            spawnFake.SpawnAgain();
            spawnFake2.SpawnAgain();
        }
    }

    //Method to handle restarting the game
    public void isRestart()
    {
        //hide the game over and win screens
        gameOverPrefab.SetActive(false);
        winPrefab.SetActive(false);
        //hide the menu
        menu.SetActive(false);
        //deactivate the spawners
        spawner.SetActive(false);
        spawner2.SetActive(false);
        spawner3.SetActive(false);
        FakeSpawner.SetActive(false);
        FakeSpawner2.SetActive(false);
        //lock the laser
        beamGestures.lockLaser = true;
        threeSecOver = false;

        //deactivate all asteroids on screen
        var clones = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < clones.Length; i++)
        {
            GameObject clone = clones[i];
            //Destroy(clone);
            clone.SetActive(false);
        }

        //start the beam gesture wait
        beamGestures.WaitStart();
        //activate Uranus and spawners again
        uranus.SetActive(true);
        spawner.SetActive(true);
        spawner2.SetActive(true);
        spawner3.SetActive(true);
        //spawn asteroids again
        spawnAsteroids.SpawnAgain();
        spawnAsteroids2.SpawnAgain();
        spawnAsteroids3.SpawnAgain();
        FakeSpawner.SetActive(true);
        FakeSpawner2.SetActive(true);
        spawnFake.SpawnAgain();
        spawnFake2.SpawnAgain();
    }

    //Method to handle quitting from the pause menu
    public void quitFromPause()
    {
        //deactivate all asteroids on screen
        var clones = GameObject.FindGameObjectsWithTag("Asteroid");
        for (int i = 0; i < clones.Length; i++)
        {
            GameObject clone = clones[i];
            clone.SetActive(false);
        }
    }

    //Method to avoid pausing game on death
    public void pauseOnDeath()
    {
        //if Uranus' health is 0, deactivate pause screen
        if (uranusLife.currentHealth == 0) pausePrefab.SetActive(false);
    }


}
