using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawneralien : MonoBehaviour
{

    private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private GameObject germSlime;
    [SerializeField] private int timeSpawn = 7;
    [SerializeField] private int aliensNumber = 3;
    [SerializeField] private bool showSpawnArea = true;
    public GameObject ground;
    


    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        //Start the coroutine we define below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());
        //germSlime.SetActive(false);
                
    }

    void Update()
    {
        center = transform.position;
    }


    //method to restart the spawner of aliens when I exit from the pause
    public void spawnAliensAgain()
    {
        center = transform.position;
         
        StartCoroutine(TimeSpawnDefiner());
    }


    IEnumerator TimeSpawnDefiner()
    {
        for(int i = 0; i<3; i++)
        {
        
            //yield on a new YieldInstruction that waits for 7 seconds.
            yield return new WaitForSeconds(timeSpawn);

            _SpawnAliens();
            
        }
    }


    //method to spawn aliens until I reach aliensNumber 
    public void _SpawnAliens()
    {
       
        for(int i=0; i<aliensNumber-1; i++)
        {
            SpawnAliens();
        }
        
    }

    //When I click on Restart on the menu I disactive all the old aliens
    public void DisactiveAliensInRestart()
    {
        var clones = GameObject.FindGameObjectsWithTag("Alien");
        for (int i = 0; i < clones.Length; i++)
        {
            GameObject clone = clones[i];
            //Destroy(clone);
            clone.SetActive(false);
        }
    }


    //method to spawn an alien in the area defined
    public void SpawnAliens()
    {
        //germSlime.SetActive(true);

        Vector3 pos = center + new Vector3(Random.Range((-size.x/2) - 0.1f , (size.x/2) - 0.1f), Random.Range((-size.y/2) - 0.1f, (size.y/2) - 0.1f), Random.Range((-size.z/2) - 0.1f, (size.z/2)- 0.1f));

        Instantiate(germSlime, pos, Quaternion.identity, ground.transform);
            
    }


    private void OnDrawGizmosSelected()
    {
        if(!showSpawnArea)
            return;

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}



