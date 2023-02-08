using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPlanets : MonoBehaviour
{

    public GameObject[] planets;
    public int collected = 0;
    PlanetsWonUranus planetsWonUranus;
    [SerializeField] private GameObject uranusPlanets;
    //[SerializeField] private GameObject marsPlanets;
    //[SerializeField] private GameObject marsPlanets1;
    public PlanetsWonNew wonMars;
    public PlanetsWonNew wonMars1;

    private void Awake()
    {
        //wonMars = marsPlanets.GetComponent<PlanetsWonNew>();
        //wonMars1 = marsPlanets1.GetComponent<PlanetsWonNew>();
        planetsWonUranus = uranusPlanets.GetComponent<PlanetsWonUranus>();
        foreach (GameObject planet in planets)
            planet.SetActive(false);
    }
    private void Update()
    {
        Debug.Log(collected);
        //UpdateVisiblePlanets(collected);
    }
    public void updatePlanets()
    {
        int num = planetsWonUranus.numberOfPlanets;
        int val = wonMars.numberOfPlanets;
        int val1 = wonMars1.numberOfPlanets;
        collected += num;
        collected += val;
        collected += val1;
        UpdateVisiblePlanets(collected);
        
    }

    public void UpdateVisiblePlanets(int val)
    {
       
        Debug.Log("Updating planets");
        for(int i = 0; i < collected; i++)
        {
            Debug.Log("adding "+i+"plantes");

            planets[i].SetActive(true);
        }
        for (int j = collected; j < 8; j++)
        {
            Debug.Log("Remaining"+j+"planets");
            planets[j].SetActive(false);
        }
    }

}
