using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToCheck : MonoBehaviour
{

    
    [SerializeField] public Text aliensFound;
    [SerializeField] public Text aliensFound1;
    [SerializeField] public float numberAliensFound = 0;
    public ParticleSystem DestroyedEffect;
    
   
    //method to check if there is an alien that collides with the area of photo and increment the number of aliens found and then eliminate the corrispondent alien, N.B. this method disactive one alien per time
    private void OnTriggerEnter(Collider other)
    {

            if(other.gameObject.CompareTag("Alien"))
            {
                Instantiate(DestroyedEffect, other.gameObject.transform.position, Quaternion.identity);
                other.gameObject.SetActive(false);
            
                if(numberAliensFound < 12) 
                {
                    numberAliensFound++;
                    aliensFound.text = string.Format("{0}", numberAliensFound); //printing the value
                    aliensFound1.text = string.Format("{0}", numberAliensFound); //printing the value in the menu
            
                }
                

                gameObject.SetActive(false); //disactivate AreaCheck during the movement of the rover
            }
           
    }



}

