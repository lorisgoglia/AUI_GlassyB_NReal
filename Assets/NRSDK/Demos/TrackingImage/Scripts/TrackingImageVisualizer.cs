using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.UI;

public class TrackingImageVisualizer : MonoBehaviour
{

    public NRTrackableImage image;
    public GameObject contorno;
    public Text text;
    public Camera mainCamera;


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
            contorno.SetActive(false);
            text.color = new Color(0, 0, 0, 0);
            return;
        }
        
        //var center = image.GetCenterPose();
        //Vector2 sizeImage image.Size;
        //transform.position = center.position;
        //transform.rotation = center.rotation;
        
        contorno.SetActive(true);
        text.color = new Color(0, 0, 0, 1);

        transform.position = new Vector3(0, 0, mainCamera.transform.position.z + 1.5f);
        



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
