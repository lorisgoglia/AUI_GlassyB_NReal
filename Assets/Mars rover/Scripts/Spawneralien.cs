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
    


    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        //Start the coroutine we define below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());
        //germSlime.SetActive(false);
                
    }


    //method to restart the spawner of aliens when I exit from the pause
    public void spawnAliensAgain()
    {
        center = transform.position;
         
        StartCoroutine(TimeSpawnDefiner());
    }


    IEnumerator TimeSpawnDefiner()
    {
        while(true)
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


    //method to spawn an alien in the area defined
    public void SpawnAliens()
    {
        //germSlime.SetActive(true);

        Vector3 pos = center + new Vector3(Random.Range((-size.x/2) - 0.1f , (size.x/2) - 0.1f), Random.Range((-size.y/2) - 0.1f, (size.y/2) - 0.1f), Random.Range((-size.z/2) - 0.1f, (size.z/2)- 0.1f));

        Instantiate(germSlime, pos, Quaternion.identity);
            
    }


    private void OnDrawGizmosSelected()
    {
        if(!showSpawnArea)
            return;

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}



