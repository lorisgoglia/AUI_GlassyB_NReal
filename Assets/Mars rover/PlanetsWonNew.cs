using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlanetsWonNew : MonoBehaviour
{
    public Text numPlanetsWon;
    public Text aliensFound;
    public Text aliensTotal;
    public int found = 0;
    public int total = 0;
    private const int four = 4;
    private const int three = 3;
    private const int two = 2;
    private const int one = 1;
    public int numberOfPlanets = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlanetsWonn();
    }

    public void PlanetsWonn()
    {

        found = Convert.ToInt32(aliensFound);
        total = Convert.ToInt32(aliensTotal);

        if(found == total)
        {
            numPlanetsWon.text = four.ToString();
            numberOfPlanets = four;
        }
        else if(found < total && found >= (total * 3/4))
        {
            numPlanetsWon.text = three.ToString();
            numberOfPlanets = three;
        }
        else if(found < (total * 3/4) && found >= (total / 2))
        {
            numPlanetsWon.text = two.ToString();
            numberOfPlanets = two;
        }
        else if(found < (total / 2) && found > 0)
        {
            numPlanetsWon.text = one.ToString();
            numberOfPlanets = one;
        }

    }

}

