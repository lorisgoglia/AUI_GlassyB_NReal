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
    //public bool restart = false;
    //private int numberOfAlien = 0;
    //public GameObject[] aliens;


    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        //Start the coroutine we define below named TimeSpawnDefiner.
        StartCoroutine(TimeSpawnDefiner());
                
    }

/*
    //Restart the spawn of aliens from the beginning (to destroy them you have to save them in an array an then destroy it)
    public void Restart(bool restart)
    {
        if(restart == true)
        {
            foreach(GameObject alien in aliens)
            {
                Destroy(alien);
            }

            Start();
        }
        
    }
*/

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
        //for (int j = 0; j< 20; j++)
        //{
            //yield on a new YieldInstruction that waits for 7 seconds.
            yield return new WaitForSeconds(timeSpawn);

            _SpawnAliens();
            //asteroidNumber++; //piu che aumentare il numero di asteroidi forse ha senso abilitare piu spawner
            //per farlo fai letteralmente uno spawner di spawner
        //}
        }
    }


    //method to spawn aliens until I reach aliensNumber 
    public void _SpawnAliens()
    {
       //numberOfAlien = num;
        for(int i=0; i<aliensNumber-1; i++)
        {
            SpawnAliens();
        }
         
    }


    //method to spawn an alien in the area defined
    public void SpawnAliens()
    {
        
        Vector3 pos = center + new Vector3(Random.Range((-size.x/2) - 0.1f , (size.x/2) - 0.1f), Random.Range((-size.y/2) - 0.1f, (size.y/2) - 0.1f), Random.Range((-size.z/2) - 0.1f, (size.z/2)- 0.1f));

       /* aliens[num2] =*/ Instantiate(germSlime, pos, Quaternion.identity);
            
    }


    private void OnDrawGizmosSelected()
    {
        if(!showSpawnArea)
            return;

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}



