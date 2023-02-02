/*
 * This script creates a spawning system for asteroids in a defined area. 
 * It uses a coroutine to spawn a number of asteroids at a given interval. 
 * The center, size, asteroid prefab, spawn interval, number of asteroids, and whether to display the spawn area in the editor can all be set 
 * in the Unity inspector. The script also has an option to spawn the asteroids again. The OnDrawGizmosSelected function draws a red cube in the 
 * editor to show the spawn area.
 */

using System.Collections;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    //Vector3 variable to store the center of the spawn area
    private Vector3 center;
    //Vector3 variable to store the size of the spawn area, set in the Inspector
    [SerializeField] private Vector3 size;
    //GameObject variable to store the asteroid prefab, set in the Inspector
    [SerializeField] private GameObject asteroidPrefab;
    //Integer variable to store the time interval between spawns, set in the Inspector
    [SerializeField] private int timeSpawn = 5;
    //Integer variable to store the number of asteroids to spawn, set in the Inspector
    [SerializeField] private int asteroidNumber = 3;
    //Boolean variable to toggle the display of the spawn area in the Scene view, set in the Inspector
    [SerializeField] private bool showSpawnArea = true;

    // Start is called before the first frame update
    void Start()
    {
        //Assign the position of the GameObject to the center variable
        center = transform.position;
        //Start the coroutine we defined below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());

    }
    public void SpawnAgain()
    {
        //Assign the position of the GameObject to the center variable
        center = transform.position;
        //Start the coroutine we defined below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());
    }

    //Coroutine to define the time interval between spawns
    IEnumerator TimeSpawnDefiner()
    {
        //Infinite loop
        while (true)
        {
            //yield on a new YieldInstruction that waits for the number of seconds defined in the timeSpawn variable.
            yield return new WaitForSeconds(timeSpawn);

            _SpawnAsteroids();
        }
    }

    //Function to spawn the asteroids
    public void _SpawnAsteroids()
    {
        //loop to spawn the number of asteroids defined in the asteroidNumber variable
        for (int i = 0; i < asteroidNumber - 1; i++)
        {
            //Call the SpawnAsteroid() function
            SpawnAsteroid();
        }
    }

    //Function to spawn a single asteroid
    public void SpawnAsteroid()
    {
        //Generate a random position within the defined spawn area//Generate a random position within the defined spawn area
        Vector3 pos = center + new Vector3(Random.Range((-size.x / 2) - 0.1f, (size.x / 2) - 0.1f), Random.Range((-size.y / 2) - 0.1f, (size.y / 2) - 0.1f), Random.Range((-size.z / 2) - 0.1f, (size.z / 2) - 0.1f));
        //instantiate the asteroid prefab at the calculated position
        Instantiate(asteroidPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        if(!showSpawnArea)
            return;
        //Draw a cube in the editor to show the spawn area
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
