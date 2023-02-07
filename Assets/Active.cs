using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject alienPink;
    public GameObject alienGreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alienPink.SetActive(true);
        alienGreen.SetActive(true);
    }
}
