using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProvaFade : MonoBehaviour
{
    public Image img;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnButtonClick()
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
    }


