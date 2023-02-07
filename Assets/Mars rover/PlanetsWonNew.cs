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
    private int found = 0;
    public int total = 12; 
    private string numFound;
    private const int four = 4;
    private const int three = 3;
    private const int two = 2;
    private const int one = 1;
    private const int zero = 0;
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
        numFound = aliensFound.text;
        found = Int32.Parse(numFound);
        

        if(found == total)
        {
            numPlanetsWon.text = four.ToString();
            numberOfPlanets = four;
        }
        else if(found < total && found >= (total * 0.75f))
        {
            numPlanetsWon.text = three.ToString();
            numberOfPlanets = three;
        }
        else if(found < (total * 0.75f) && found >= (total / 2.0f))
        {
            numPlanetsWon.text = two.ToString();
            numberOfPlanets = two;
        }
        else if(found < (total / 2.0f) && found > 0)
        {
            numPlanetsWon.text = one.ToString();
            numberOfPlanets = one;
        }else
        {
            numPlanetsWon.text = zero.ToString();
            numberOfPlanets = zero;
        }
        

    }

}

