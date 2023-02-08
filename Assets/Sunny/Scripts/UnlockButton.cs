using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour
{
    // Start is called before the first frame update
    public MeshRenderer renderer;
    
  
    // Update is called once per frame
    void Update()
    {
        if (renderer.enabled)
            GetComponent<Interactable>().enabled = true;
        else
            GetComponent<Interactable>().enabled = false;

    }
}
