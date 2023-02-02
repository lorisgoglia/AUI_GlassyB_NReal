/*
 * This script manages the display and rotation of heart objects that represent the health of an object named "Uranus." 
 * The script uses the "UranusLife" component to track Uranus' health, and based on that value, it activates and deactivates different heart objects. 
 * The script also manages the rotation of the heart objects and the rotation speed changes based on the Uranus' health value. 
 * The script also checks the status of win, game over, and pause menus and modifies the behavior accordingly.
 */

using UnityEngine;

public class HeartsManager : MonoBehaviour
{

    // Serialized fields for the heart objects
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    [SerializeField] private GameObject heart4;
    [SerializeField] private GameObject heart5;
    // Reference to UranusLife script
    UranusLife uranusLife;
    // Serialized fields for Uranus and the game over, win, and pause menus
    [SerializeField] private GameObject uranus;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    // Variable for the speed at which the hearts rotate
    public float rotSpeed = 0.1f;


    private void Awake()
    {
        // Get the UranusLife component from the Uranus object
        uranusLife = uranus.GetComponent <UranusLife>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call the numberOfHearts, heartsMovement, and heartsSpeed functions
        numberOfHearts();
        heartsMovement();
        heartsSpeed();
    }

    void numberOfHearts()
    {
        // Check the current health of Uranus
        if (uranusLife.currentHealth == 6)
        {
            // Check if the win or game over menu are not active
            if (winMenu.activeInHierarchy == false && gameOverMenu.activeInHierarchy == false)
            {
                //Show all hearts
                heart.SetActive(true);
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
            }
            else
            {
                // Hide all hearts
                heart.SetActive(false);
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                heart4.SetActive(false);
                heart5.SetActive(false);
            }
        }
        // Repeat the same process for each currentHealth possible value, activing the correspoding number of hearts
        else if (uranusLife.currentHealth == 5)
        {
            heart.SetActive(true);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if (uranusLife.currentHealth == 4)
        {
            heart.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(true);
            heart5.SetActive(false);
        }
        else if (uranusLife.currentHealth == 3)
        {
            heart.SetActive(false);
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (uranusLife.currentHealth == 2)
        {
            heart.SetActive(false);
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(true);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (uranusLife.currentHealth == 1)
        {
            heart.SetActive(false);
            heart1.SetActive(false);
            heart2.SetActive(true);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else if (uranusLife.currentHealth == 0)
        {
            heart.SetActive(false);
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
        else
        {
            heart.SetActive(false);
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);
            heart4.SetActive(false);
            heart5.SetActive(false);
        }
    }

    //Manages the rotation of the hearts
    void heartsMovement()
    {
        // check if the pause menu is not active
        if (pauseMenu.activeInHierarchy == false)
        {
            // rotate the hearts
            heart.transform.Rotate(0, 0, rotSpeed);
            heart1.transform.Rotate(0, 0, -rotSpeed);
            heart2.transform.Rotate(0, 0, rotSpeed);
            heart3.transform.Rotate(0, 0, -rotSpeed);
            heart4.transform.Rotate(0, 0, rotSpeed);
            heart5.transform.Rotate(0, 0, -rotSpeed);
        }
        else
        {
            // if the pause menu is active, stop rotating the hearts
            heart.transform.Rotate(0, 0, 0);
            heart1.transform.Rotate(0, 0, 0);
            heart2.transform.Rotate(0, 0, 0);
            heart3.transform.Rotate(0, 0, 0);
            heart4.transform.Rotate(0, 0, 0);
            heart5.transform.Rotate(0, 0, 0);
        }
    }

    void heartsSpeed()
    {
        // check if current health is equal to maximum health
        if (uranusLife.currentHealth == uranusLife.maxHealth)
        {
            // if yes, set rotation speed to 0.2
            rotSpeed = 0.2f;
        }
        // check if current health is greater than half of maximum health
        else if (uranusLife.currentHealth > uranusLife.maxHealth / 2)
        {
            // if yes, set rotation speed to 0.4
            rotSpeed = 0.4f;
        }
        // check if current health is equal to half of maximum health
        else if (uranusLife.currentHealth == uranusLife.maxHealth / 2)
        {
            // if yes, set rotation speed to 0.6
            rotSpeed = 0.6f;
        }
        // check if current health is less than half of maximum health
        else if (uranusLife.currentHealth < uranusLife.maxHealth / 2)
        {
            // if yes, set rotation speed to 0.8
            rotSpeed = 0.8f;
        }
    }
}
