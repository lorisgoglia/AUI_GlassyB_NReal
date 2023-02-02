using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulateImageTracking : MonoBehaviour
{


    [SerializeField] public GameObject btn;
    [SerializeField] public Image img;
    MeshRenderer meshRenderer;

    private void Awake()
    {

        meshRenderer = btn.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
    public void ImageTracked()
    {
        meshRenderer.enabled = true;
    }

    public void StartFading()
    {
        // fades the image out when you click
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {

        // loop over 1 second
        for (float i = 0; i <= 255; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(255, 255, 255, i);
            yield return null;
        }
    }
}
