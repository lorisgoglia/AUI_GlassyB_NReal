using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoStraight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    public float Force;
    
    
    // Update is called once per frame and used to go straight if the button is pressed
    void Update()
    {
        if(isPressed)
        {
            Player.transform.Translate(0, Terrain.activeTerrain.SampleHeight(transform.position), Force * Time.deltaTime);
            
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

     public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void Go(){
        Player.transform.Translate(0, Terrain.activeTerrain.SampleHeight(transform.position), Force * Time.deltaTime);

    }

    
}

