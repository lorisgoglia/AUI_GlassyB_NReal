/*
 * This script plays different audio clips based on the string passed to the PlaySound() function. 
 * The audio clips are loaded from the Resources folder and the script uses a static AudioSource component to play them. 
 * The Start() method is used to load the audio clips and get the AudioSource component. 
 * The script uses the PlaySound(string clip) method to play the corresponding audio clip based on the string passed to it.
 */

using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Declaring variables for all the audio clips
    public static AudioClip asteroidImpact, continuousBeam, reloading, uranusExplosion;
    // AudioSource component that will play the audio
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // Loading the audio clips from the Resources folder
        asteroidImpact = Resources.Load<AudioClip>("asteroidImpact");
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
            case "impact":
                // Playing the asteroidImpact audio clip
                audioSrc.PlayOneShot(asteroidImpact);
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

