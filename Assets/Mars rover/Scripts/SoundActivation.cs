using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivation : MonoBehaviour
{
    // Declaring variables for all the audio clips
    public static AudioClip germSound, photoEffect;
    // AudioSource component that will play the audio
    static AudioSource audioSrc;

    
    // Start is called before the first frame update
    void Start()
    {
        // Loading the audio clips from the Resources folder
        germSound = Resources.Load<AudioClip>("SFX_EnemyHit03");
        photoEffect = Resources.Load<AudioClip>("camera-shutter-click-01");
        
        audioSrc = GetComponent<AudioSource>();

    }

    // Function to play the sound based on the clip passed
    public static void PlaySound(string clip)
    {
        // Switch statement to check which clip to play
        switch (clip)
        {
            case "germSound":
                // Playing the germSound audio clip
                audioSrc.PlayOneShot(germSound);
                break;
            case "photoEffect":
                // Playing the photoEffect audio clip
                audioSrc.PlayOneShot(photoEffect);
                break;
        }
    }
}


