/*
This script calculates the number of planets won based on the current health of a game object named "Uranus".
The script updates a UI Text element to display the number of planets won and also updates a variable to store the number of planets won.
The script uses three constants, one for three planets, one for two planets, and one for one planet.
The script uses an if-else statement to determine the number of planets won based on the current health of Uranus and
updates the UI Text element and the variable accordingly.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetsWonUranus : MonoBehaviour
{
    // Reference to the UI Text element to display the number of planets won
    public Text planetsWon;

    // Reference to the UranusLife script component attached to the Uranus object
    UranusLife uranusLife;

    // Reference to the Uranus object in the scene
    [SerializeField] private GameObject uranus;

    // Constants for the number of planets won
    private const int four = 4;
    private const int three = 3;
    private const int two = 2;
    private const int one = 1;

    // Variable to store the number of planets won
    public int numberOfPlanets = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get the UranusLife script component attached to the Uranus object
        uranusLife = uranus.GetComponent<UranusLife>();
    }

    // Update is called once per frame
    void Update()
    {
        PlanetsWon();
    }

    // Method to determine the number of planets won based on the current health of Uranus
    public void PlanetsWon()
    {
        // If Uranus has full health, set the number of planets won to 4 and update the UI Text element
        if (uranusLife.currentHealth == uranusLife.maxHealth)
        {
            planetsWon.text = four.ToString();
            numberOfPlanets = four;
        }
        // If Uranus has more than half health, set the number of planets won to 3 and update the UI Text element
        else if (uranusLife.currentHealth < uranusLife.maxHealth && uranusLife.currentHealth > (uranusLife.maxHealth / 2))
        {
            planetsWon.text = three.ToString();
            numberOfPlanets = three;
        }
        // If Uranus has half health, set the number of planets won to 2 and update the UI Text element
        else if (uranusLife.currentHealth < uranusLife.maxHealth && uranusLife.currentHealth == (uranusLife.maxHealth / 2))
        {
            planetsWon.text = two.ToString();
            numberOfPlanets = two;
        }
        // If Uranus has less than half health, set the number of planets won to 1 and update the UI Text element
        else if (uranusLife.currentHealth < (uranusLife.maxHealth / 2) && uranusLife.currentHealth > 0)
        {
            planetsWon.text = one.ToString();
            numberOfPlanets = one;
        }
    }
}
