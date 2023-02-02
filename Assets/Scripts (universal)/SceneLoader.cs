using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //serve per gestire le scene

public class SceneLoader : MonoBehaviour
{

    //fa il loading della scena successiva
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    //dovremo cambiarlo quando aggiungeremo la scena di marte con le quest (stile google maps)
    public void LoadMarsScene()
    {
        SceneManager.LoadScene(1);
    }

    //method che va al minigioco di Urano
    public void LoadUranusScene()
    {
        SceneManager.LoadScene(2);
    }


    //method che ritorna alla scena iniziale
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);

    }

    //method che ricarica la scena stessa
    public void ResetScene()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
