using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
{

    public NRTrackableImage image;
    public bool imageRecognized = false;
    


    [SerializeField] public GameObject btnMars;
    [SerializeField] public GameObject btnUranus;
    MeshRenderer meshRendererMars;
    MeshRenderer meshRendererUranus;

    





    private void Awake()
    {

        meshRendererMars = btnMars.GetComponent<MeshRenderer>();
        meshRendererUranus = btnUranus.GetComponent<MeshRenderer>();

        meshRendererMars.enabled = false;
        meshRendererUranus.enabled = false;


    }
    private void Update()
    {
        if (image == null)
        {

            return;
        }
        else
        {

            //var center = image.GetCenterPose();
            //Vector2 sizeImage = image.Size;
            //transform.position = center.position;
            //transform.rotation = center.rotation;

            if (imageRecognized == false)
            {
                imageRecognized = true;

            }
        }

        
        if (image.GetDataBaseIndex() == 0)
        {

            //attiva bottone gioco marte
            meshRendererMars.enabled = true;

            //btnMars.Interactable = true;
        }
        else if (image.GetDataBaseIndex() == 1)
        {
            //attiva bottone gioco urano
            meshRendererUranus.enabled = true;

            //btnUranus.interactable = true;

        }
        

        

    }


    /*
   public void StartFading()
   {
       // fades the image out when you click
       StartCoroutine(FadeImage());
   }


   IEnumerator FadeImage()
   {

       // loop over 1 second
       for (float i = 0; i <= 1; i += Time.deltaTime)
       {
           // set color with i as alpha
           img.color = new Color(1, 1, 1, i);
           yield return null;
       }
   }
   */

   

    
}

