/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetAliens : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public GameObject targetPlayer;
    public LayerMask obstacleMask;
    public bool enabled = false;
    public GameObject player;
    

    void Update()
   {
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;
        
        if (Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
        {
            Debug.Log("ciao");
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToTarget <= viewRadius)
            {
                if(Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == false)
                {
                    AlienSeen(enabled);
                    
                }
            }
        }
    }



   public void AlienSeen(bool en)
   {
     if(en == true)
     {
         Debug.Log("I have seen you!");
     }
                    
       
        
   }
   
}*/

