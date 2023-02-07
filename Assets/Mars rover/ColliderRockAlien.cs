using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderRockAlien : MonoBehaviour
{
   

    void Start()
    {

    }
    void Update()
    {
        SoundManagerScript.PlaySound("germSound");
    }

    

    //move back the alien when find a rock or another alien
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rock"))
        {
            transform.Translate(0, 0, -5);

        }else if(other.gameObject.CompareTag("Alien"))
        {
            transform.Translate(0, 0, -100);
        }
        
    }

    
}
