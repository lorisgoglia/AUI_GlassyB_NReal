using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject hidedScene;

    //Method used to keep the roverView canvas disactivated when I'm not taking photos
    void Update()
    {
        hidedScene.SetActive(false);
    }
}

