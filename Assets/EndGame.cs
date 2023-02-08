using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public DialogueTrigger dialogueTriggerWin;
    [SerializeField] private GameObject scene;
    public DialogueTrigger dialogueTriggerLost;
    public DialogueTrigger dialogueTriggerGoing;

    public bool isGameWon = false;
    public bool isGameLost = false;
    public bool isUranusFinished = false;

    private void Start()
    {

    }
    private void Update()
    {
        if (scene.activeInHierarchy && isGameWon)
        {
            dialogueTriggerWin.TriggerDialogue();
        }else if(scene.activeInHierarchy && isUranusFinished)
        {
            dialogueTriggerGoing.TriggerDialogue();
        }
        else if (scene.activeInHierarchy && isGameLost)
        {
            dialogueTriggerLost.TriggerDialogue();
        }

    }


}
