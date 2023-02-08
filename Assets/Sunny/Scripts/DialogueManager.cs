using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshPro nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    private Queue<string> sentencesBack;
    public GameObject nextbtn;
    public GameObject lettera;
    public GameObject schiaparelli;
    public GameObject oriani;
    public GameObject marsMap;
    public GameObject cerulli;
    public GameObject uranusTel;
    public GameObject uranusImg;
    public GameObject marsTel;
    public GameObject marsImg;


    public bool tutorialOver = false;
    public Animator animator;

    private int counter = -1;
    

    void Start()
    {
        sentences = new Queue<string>();
        sentencesBack = new Queue<string>();

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
        counter = -1;
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

        //img.SetActive(false);


        if (sentences.Count == counter)
        {
            EndDialogue();
            return;
        }

        counter++;

        string sentence = (string)sentences.ToArray().GetValue(counter);
        Debug.Log(sentence);

        if(sentence == "Through a large collaboration and exchange of data between Paris and Brera," +
            " Boscovich shared the information he received from Messier with his colleagues in Brera.")
        {
            lettera.SetActive(true);
        }else if(sentence == "In his papers Schiaparelli called these “canali”, based on " +
            "similar features that characterize Earth’s geography. He certainly did not expect " +
            "to start a controversy that would last for decades!")
        {
            marsMap.SetActive(true);
        }
        else if (sentence == "The real origin of the Mars canals was revealed by another italian astronomer," +
            " Vincenzo Cerulli.  He gave a convincing explanation, still generally accepted, after he himself" +
            " observed Mars through a larger and more powerful telescope. ")
        {
            cerulli.SetActive(true);
        }
        else if (sentence == "In 1877 Schiaparelli published his first map of the planet Mars. This new and more " +
            "precise map contained a web of fine straight lines, that would become even more complex in future maps.")
        {
            schiaparelli.SetActive(true);
        }
        else if (sentence == "It was thanks to Barnaba Oriani, astronomer of Brera ,that significant progress on " +
            "the study of Uranus was made.")
        {
            oriani.SetActive(true);
        }
        else if (sentence == "First, search on the attraction I'm showing you and do image recognition of the image above. Click NEXT to know how.")
        {
            uranusTel.SetActive(true);
            uranusImg.SetActive(true);


        }
        else if (sentence == "Now you can go in this attraction and do image recognition of the image above")
        {
            marsImg.SetActive(true);
            marsTel.SetActive(true);
        }
        else
        {
            oriani.SetActive(false);
            schiaparelli.SetActive(false);
            cerulli.SetActive(false);
            marsMap.SetActive(false);
            lettera.SetActive(false);

            uranusTel.SetActive(false);
            uranusImg.SetActive(false);

            marsImg.SetActive(false);
            marsTel.SetActive(false);

        }

        if(sentence == "Finally , when you feel ready , click the “PLAY” button to start the game. GOOD LUCK !!!")
            tutorialOver = true;

        dialogueText.text = sentence;
        //sentencesBack.Enqueue(sentence);

        Debug.Log(sentences);
        Debug.Log(sentencesBack);

    }

    public void DisplayPreviousSentence()
    {
        Debug.Log("[DisplayNextSentence running]");

        //img.SetActive(false);

        counter--;

        string sentence = (string)sentences.ToArray().GetValue(counter);
        Debug.Log(sentence);

        if (sentence == "Through a large collaboration and exchange of data between Paris and Brera," +
            " Boscovich shared the information he received from Messier with his colleagues in Brera.")
        {
            lettera.SetActive(true);
        }
        else if (sentence == "In his papers Schiaparelli called these “canali”, based on " +
           "similar features that characterize Earth’s geography. He certainly did not expect " +
           "to start a controversy that would last for decades!")
        {
            marsMap.SetActive(true);
        }
        else if (sentence == "The real origin of the Mars canals was revealed by another italian astronomer," +
            " Vincenzo Cerulli.  He gave a convincing explanation, still generally accepted, after he himself" +
            " observed Mars through a larger and more powerful telescope. ")
        {
            cerulli.SetActive(true);
        }
        else if (sentence == "In 1877 Schiaparelli published his first map of the planet Mars. This new and more " +
            "precise map contained a web of fine straight lines, that would become even more complex in future maps.")
        {
            schiaparelli.SetActive(true);
        }
        else if (sentence == "It was thanks to Barnaba Oriani, astronomer of Brera ,that significant progress on " +
            "the study of Uranus was made.")
        {
            oriani.SetActive(true);
        }
        else if (sentence == "First, search on the attraction I'm showing you and do image recognition of the image above. Click NEXT to know how.")
        {
            uranusTel.SetActive(true);
            uranusImg.SetActive(true);


        }
        else if (sentence == "Now you can go in this attraction and do image recognition of the image above")
        {
            marsImg.SetActive(true);
            marsTel.SetActive(true);
        }
        else
        {
            oriani.SetActive(false);
            schiaparelli.SetActive(false);
            cerulli.SetActive(false);
            marsMap.SetActive(false);
            lettera.SetActive(false);

            uranusTel.SetActive(false);
            uranusImg.SetActive(false);

            marsImg.SetActive(false);
            marsTel.SetActive(false);

        }

        if (sentence == "Finally , when you feel ready , click the “PLAY” button to start the game. GOOD LUCK !!!")
            tutorialOver = true;



        dialogueText.text = sentence;
        //sentences.Enqueue(sentence);

        Debug.Log(sentences);
        Debug.Log(sentencesBack);


    }

    public void DisplayLastSentence()
    {
        counter = sentences.Count-1;

        string sentence = (string)sentences.ToArray().GetValue(counter);
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
