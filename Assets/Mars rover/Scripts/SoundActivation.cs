using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundActivation : MonoBehaviour
{
    // Declaring variables for all the audio clips
    public static AudioClip germSound, continuousBeam, reloading, uranusExplosion;
    // AudioSource component that will play the audio
    static AudioSource audioSrc;

    void Update()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        // Loading the audio clips from the Resources folder
        germSound = Resources.Load<AudioClip>("SFX_GermIdle");
        continuousBeam = Resources.Load<AudioClip>("continuous_beam_1");
        reloading = Resources.Load<AudioClip>("reloading_008");
        uranusExplosion = Resources.Load<AudioClip>("UranusExplosion");
        // Getting the AudioSource component from the GameObject
        audioSrc = GetComponent<AudioSource>();

    }

    // Function to play the sound based on the clip passed
    public static void PlaySound(string clip)
    {
        // Switch statement to check which clip to play
        switch (clip)
        {
            case "germSound":
                // Playing the asteroidImpact audio clip
                audioSrc.PlayOneShot(germSound);
                break;
            case "beam":
                // Playing the continuousBeam audio clip
                audioSrc.PlayOneShot(continuousBeam);
                break;
            case "uranusExplosion":
                // Playing the uranusExplosion audio clip
                audioSrc.PlayOneShot(uranusExplosion);
                break;
            case "reloading":
                // Playing the reloading audio clip
                audioSrc.PlayOneShot(reloading);
                break;
        }
    }
}


