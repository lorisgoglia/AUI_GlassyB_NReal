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
    public Canvas canvas;
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
            contorno.SetActive(false);
            text.color = new Color(0, 0, 0, 0);
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
                StartCoroutine(TimeWaiting());

            }
        }

        /*
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
        

        */

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

    IEnumerator TimeWaiting()
    {

        Debug.Log("running IEnumerator");
        int i = 0;
        while (i<=1)
        {
            Debug.Log("sono nel while");
            if (i == 1)
            {
                Debug.Log("sono nel if");

                contorno.SetActive(false);
                text.color = new Color(0, 0, 0, 0);
                break;
            }
            Debug.Log("sono nel while dopo if");

            contorno.SetActive(true);
            text.color = new Color(0, 0, 0, 1);
            canvas.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z + 1);
            
            i++;
            yield return new WaitForSeconds(5f);


        }

    }
}

