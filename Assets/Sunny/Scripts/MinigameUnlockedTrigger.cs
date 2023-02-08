using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameUnlockedTrigger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    DialogueTrigger dialogueTrigger;


    public GameObject imageRecognized;

    private void Awake()
    {

        meshRenderer = GetComponent<MeshRenderer>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Update()
    {
        if (meshRenderer.enabled == true)
        {
            dialogueTrigger.TriggerDialogue();
            imageRecognized.SetActive(true);

            //enabled = false;

        }

    }

}
