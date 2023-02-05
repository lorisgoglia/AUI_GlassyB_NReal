using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginTutorial : MonoBehaviour
{
    DialogueTrigger dialogueTrigger;
    [SerializeField] private GameObject scene;

    private void Start()
    {
        dialogueTrigger = scene.GetComponent<DialogueTrigger>();

    }
    private void Update()
    {
        if (scene.activeInHierarchy)
        {
            dialogueTrigger.TriggerDialogue();
            this.enabled = false;
        }
        
    }

    
}
