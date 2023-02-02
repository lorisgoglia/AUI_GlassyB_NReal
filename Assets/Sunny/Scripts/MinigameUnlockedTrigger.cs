using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameUnlockedTrigger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    DialogueTrigger dialogueTrigger;

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
            enabled = false;
        }
    }
}
