/*
 * This script uses hand gestures from the user to control the game's laser in the tutorial phase.
 * The script uses coroutines to manage the duration of the laser.
 * The script also uses switch statements to check the current hand gesture of the right hand and performs different actions based on
 * the gesture. Moreover, the script sets the position and rotation of the laser to match the position and rotation of the user's right hand. 
 */

using System.Collections;
using UnityEngine;
using NRKernal;

public class BeamTutorial : MonoBehaviour
{
    DialogueManager dialogueManager;
    [SerializeField] private GameObject dialogMan;
    [SerializeField] private GameObject laser; // reference to the laser object
    [SerializeField] private float laserDuration = 3f; // duration of the laser
    private bool isOpen; // is the hand open or not
    private Pose rightHandPose; // right hand pose
    private Pose rightHandPointerPose; // right hand pointer pose

    //Manages the time duration of the laser
    IEnumerator LaserDeactivator()
    {
        // check if the hand is not open, win prefab, over prefab and pause prefab are inactive, and laser is not locked
        if (!isOpen)
        {
            laser.SetActive(true); // activate the laser
            SoundManagerScript.PlaySound("beam"); // play the beam sound
            yield return new WaitForSeconds(laserDuration); // wait for laserDuration
            laser.SetActive(false); // deactivate the laser
        }
    }

    private void Start()
    {
        dialogueManager = dialogMan.GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current hand state for the right hand
        HandState rightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        // If there is no right hand state, exit the method
        if (rightHandState == null)
            return;

        // Check the current gesture of the right hand
        switch (rightHandState.currentGesture)
        {
            case HandGesture.Point:
                // Do nothing if the gesture is pointing
                break;
            case HandGesture.Grab:
                // Set isOpen to false and deactivate the laser if the gesture is a grab
                isOpen = false;
                laser.SetActive(false);
                break;
            case HandGesture.Victory:
                // Do nothing if the gesture is a victory sign
                break;
            case HandGesture.OpenHand:
                // Enable the laser only if the tutorial is finished
                if (dialogueManager.tutorialOver == true)
                {
                    // Start the laser deactivation coroutine and set isOpen to true if the gesture is an open hand
                    StartCoroutine(LaserDeactivator());
                    isOpen = true;
                }
                break;
            default:
                // Deactivate the laser if the gesture is none of the above
                laser.SetActive(false);
                break;
        }

        //Get the joint pose of the right hand's palm
        rightHandPose = rightHandState.GetJointPose(HandJointID.Palm);
        //Get the pointer pose of the right hand
        rightHandPointerPose = rightHandState.pointerPose;
        //Set the position and rotation of the laser to match the right hand's palm position and pointer rotation
        laser.transform.SetPositionAndRotation(rightHandPose.position, rightHandPointerPose.rotation);

    }
}
