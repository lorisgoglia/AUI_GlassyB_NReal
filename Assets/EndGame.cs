using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;
    [SerializeField] private GameObject scene;
    bool isGameEnded = false;

    private void Start()
    {
        dialogueTrigger = scene.GetComponent<DialogueTrigger>();

    }
    private void Update()
    {
        if (scene.activeInHierarchy && isGameEnded)
        {
            dialogueTrigger.TriggerDialogue();
            this.enabled = false;
        }

    }


}
