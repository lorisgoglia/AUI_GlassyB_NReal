/*
 * This script uses hand gestures from the user to control the game's laser and pause feature. 
 * The script uses coroutines to manage the duration of the laser and the time until the game starts. 
 * The script also uses switch statements to check the current hand gesture of the left and right hand and performs different actions based on
 * the gesture. Moreover, the script sets the position and rotation of the laser to match the position and rotation of the user's right hand. 
 * Additionally, it has a GoPause() function that can be called to open the pause menu.
 */

using System.Collections;
using UnityEngine;
using NRKernal;


public class BeamGestures : MonoBehaviour
{
    [SerializeField] private GameObject laser; // reference to the laser object
    [SerializeField] private GameObject winPrefab; // reference to the win prefab
    [SerializeField] private GameObject overPrefab; // reference to the over prefab
    [SerializeField] private GameObject pausePrefab; // reference to the pause prefab
    [SerializeField] private GameObject menu; // reference to the menu object
    [SerializeField] private float laserDuration = 3f; // duration of the laser
    private bool isOpen; // is the hand open or not
    private Pose rightHandPose; // right hand pose
    private Pose rightHandPointerPose; // right hand pointer pose
    public bool lockLaser = true; // variable to lock the laser
    public bool lockPause = true; // variable to lock the pause

    private void Start()
    {
        WaitStart(); // call the WaitStart function
    }

    public void WaitStart()
    {
        StartCoroutine(WaitForStart()); // start the WaitForStart coroutine
    }

    //Wait until the game starts and than unlocks the possibility to go in pause or use the laser
    IEnumerator WaitForStart()
    {
        lockLaser = true; // lock the laser
        lockPause = true; // lock the pause
        yield return new WaitForSeconds(4); // wait for 4 seconds
        lockLaser = false; // unlock the laser
        lockPause = false; // unlock the pause
    }

    //Manages the time duration of the laser
    IEnumerator LaserDeactivator()
    {
        // check if the hand is not open, win prefab, over prefab and pause prefab are inactive, and laser is not locked
        if ((!isOpen) && (winPrefab.activeInHierarchy == false && overPrefab.activeInHierarchy == false && pausePrefab.activeInHierarchy == false) && lockLaser == false)
        {
            laser.SetActive(true); // activate the laser
            SoundManagerScript.PlaySound("beam"); // play the beam sound
            yield return new WaitForSeconds(laserDuration); // wait for laserDuration
            laser.SetActive(false); // deactivate the laser
        }
    }

    private void Update()
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
                // Start the laser deactivation coroutine and set isOpen to true if the gesture is an open hand
                StartCoroutine(LaserDeactivator());
                isOpen = true;
                break;
            default:
                // Deactivate the laser if the gesture is none of the above
                laser.SetActive(false);
                break;
        }

        // Get the current hand state for the left hand
        HandState leftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);
        // If there is no left hand state, exit the method
        if (leftHandState == null)
            return;

        switch (leftHandState.currentGesture)
        {
            case HandGesture.Point:
                // Do nothing if the gesture is pointing
                break;
            case HandGesture.Grab:
                // Do nothing if the gesture is grabbing
                break; 
            case HandGesture.Victory:
                // Do nothing if the gesture is a victory sign
                break;
            case HandGesture.OpenHand:
                // Show the pause menu and hide the other menus if the gesture is an open hand and lockPause is false
                if (lockPause == false)
                {
                    menu.SetActive(true);
                    pausePrefab.SetActive(true);
                    winPrefab.SetActive(false);
                    overPrefab.SetActive(false);
                }
                break;
            default:
            break;
        }


        //Get the joint pose of the right hand's palm
        rightHandPose = rightHandState.GetJointPose(HandJointID.Palm);
        //Get the pointer pose of the right hand
        rightHandPointerPose = rightHandState.pointerPose;
        //Set the position and rotation of the laser to match the right hand's palm position and pointer rotation
        laser.transform.SetPositionAndRotation(rightHandPose.position, rightHandPointerPose.rotation);

    }

    public void GoPause()
    {
        //Check if the laser is locked
        if (lockLaser == false)
        {
            //Activate the menu, deactivate the win and over prefabs, and activate the pause prefab
            menu.SetActive(true);
            winPrefab.SetActive(false);
            pausePrefab.SetActive(true);
            overPrefab.SetActive(false);
        }
    }

}
