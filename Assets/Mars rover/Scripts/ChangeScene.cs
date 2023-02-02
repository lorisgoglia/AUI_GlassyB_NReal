using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject hidedScene;

    // Update is called once per frame
    void Update()
    {
        hidedScene.SetActive(false);
    }
}

