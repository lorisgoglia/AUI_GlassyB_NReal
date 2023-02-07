using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameUnlockedTrigger : MonoBehaviour
{
    MeshRenderer meshRenderer;
    DialogueTrigger dialogueTrigger;


    public GameObject contorno;
    public Text text;
    public Camera mainCamera;
    public Canvas canvas;

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
            StartCoroutine(TimeWaiting());
            enabled = false;

        }
        else
        {
            contorno.SetActive(false);
            text.color = new Color(0, 0, 0, 0);
        }
    }
    IEnumerator TimeWaiting()
    {

        Debug.Log("running IEnumerator");
        int i = 0;
        while (i <= 1)
        {
            Debug.Log("sono nel while");
            if (i == 1)
            {
                Debug.Log("sono nel if");

                contorno.SetActive(false);
                text.color = new Color(0, 0, 0, 0);
                break;
            }
            Debug.Log("sono nel while dopo if");

            contorno.SetActive(true);
            text.color = new Color(0, 0, 0, 1);
            canvas.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z + 1);

            i++;
            yield return new WaitForSeconds(5f);


        }
    }
}
