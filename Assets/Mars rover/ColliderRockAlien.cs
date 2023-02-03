using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderRockAlien : MonoBehaviour
{

   
    // Start is called before the first frame update
    

    //move back the alien when find a rock 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Rock"))
        {
            transform.Translate(0, 0, -5);
        }
        
    }
}
