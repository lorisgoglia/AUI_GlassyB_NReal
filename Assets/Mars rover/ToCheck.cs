using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToCheck : MonoBehaviour
{

    [SerializeField] private bool value = false;
    [SerializeField] public Text aliensFound;
    [SerializeField] public float numberAliensFound = 0;
    public ParticleSystem DestroyedEffect;
    //public AudioSource AudioEffect;

    
    
    
    //method to check if there is an alien that collides with the area of photo and increment the number of aliens found and then eliminate the corrispondent alien, N.B. this method check one alien per time
    private void OnTriggerEnter(Collider other)
    {

            if(other.gameObject.CompareTag("Alien"))
            {
               /* var aliens = other.gameObject;
                if((aliens[1] != null))
                {
                    Instantiate(DestroyedEffect, aliens[0].transform.position, Quaternion.identity);
                    aliens[0].SetActive(false);
                }
                else*/ //controllo per far si che prenda un solo alieno alla volta nell'inquadratura
                
                Instantiate(DestroyedEffect, other.gameObject.transform.position, Quaternion.identity);
                //gameObject.GetComponent<AudioSource>().Play();
                other.gameObject.SetActive(false);
                
               // Debug.Log("object {i} is an Alien");
                
                if(numberAliensFound < 10)
                {
                    numberAliensFound++;
                    aliensFound.text = string.Format("{0}", numberAliensFound); //printing the value
            
                }
                value = false;

                gameObject.SetActive(false); //disactivate AreaCheck during the movement of the rover
            }
           
    }



}

