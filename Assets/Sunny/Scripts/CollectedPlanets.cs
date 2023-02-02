using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedPlanets : MonoBehaviour
{

    public GameObject[] planets;
    public int collected=0;
    PlanetsWonUranus planetsWonUranus;
    [SerializeField] private GameObject uranusPlanets;

    private void Awake()
    {

        planetsWonUranus = uranusPlanets.GetComponent<PlanetsWonUranus>();
        foreach (GameObject planet in planets)
            planet.SetActive(false);
    }
    private void Update()
    {
        UpdateVisiblePlanets();
    }
    public void updatePlanets()
    {
        int num = planetsWonUranus.numberOfPlanets;
        collected += num;
    }

    public void UpdateVisiblePlanets()
    {
        for(int i = 0; i < collected; i++)
        {
            planets[i].SetActive(true);
        }
        for (int i = collected; i < 9; i++)
        {
            planets[i].SetActive(false);
        }
    }

}
