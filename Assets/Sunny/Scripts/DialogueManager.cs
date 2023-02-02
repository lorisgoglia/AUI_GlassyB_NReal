using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject nextbtn;
    //Image img;

    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        //img = btn.GetComponent<Image>();
        //img.color = new Color(255, 255, 255, 255);

    }

    /*
    private void Awake()
    {
        nextbtn.SetActive(false);
    }
    */

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("[StartDialogue running]");
        //nameText.text = dialogue.name;

        sentences.Clear();

        animator.SetBool("IsIn", true);
        //nextbtn.SetActive(true);



        //FindObjectOfType<DialogueCanvas>().FadeCanvas(false);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (var item in sentences)
        {
            Debug.Log(item);
        }

        //StartCoroutine(TimeWaitingNextSentence());
        DisplayNextSentence();


        return;
    }

    IEnumerator TimeWaitingNextSentence()
    {

        Debug.Log("running IEnumerator");

        Debug.Log(sentences.Count);
        while (sentences.Count >= 0)
        {

            DisplayNextSentence();
            yield return new WaitForSeconds(5f);


        }

    }
    public void DisplayNextSentence()
    {
        Debug.Log("[DisplayNextSentence running]");


        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }



        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

        dialogueText.text = sentence;

    }
    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        //FindObjectOfType<DialogueCanvas>().FadeCanvas(true);


        animator.SetBool("IsIn", false);
        //nextbtn.SetActive(false);

        //text.color = new Color(1, 1, 1, 1);

        //StartCoroutine(FadeImage());

    }
    /*
    IEnumerator FadeImage()
    {

        // loop over 1 second
        for (float i = 94; i <= 255; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(255, 255, 255, i);
            yield return null;
        }
    }
    */




}
