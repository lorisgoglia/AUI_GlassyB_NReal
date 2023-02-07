using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NRKernal.NRExamples;
using NRKernal;


//This script is used to controll the general gestures allowed in the game, it's also used to start the movement of the ground. To move forward and backward I shift the ground, instead I rotate the rover to manage the general rotation of the game. 
public class MovementRover : MonoBehaviour
{

    private Pose rightHandPose;
    private Pose rightHandPointerPose;
    public Collider1 collider;
    private Vector3 pos;
    public float rotationSpeed = 5.0f;
    private Vector3 startPosition = new Vector3(0f,0f,0f);
    private Vector3 handPosition;
    private Rigidbody rigid;
    private bool go = false;
    private Vector3 newPosition;
    private Vector3 oldPosition;
    public GameObject rover;
    public GameObject roverView;
    public GameObject game;
    public GameObject areaCheck;
    public Timer time;
    
    
    
    void Start()
    {
        pos = transform.position;
        rigid = GetComponent<Rigidbody>();

    }

    // This method allows the movement of the ground relative to the rover with hand gestures, open hand to go forward, close hand to stop, move the arm to the right to go rght, move the arm to the left to turn left
    void Update()
    {
        HandState rightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        if (rightHandState == null)
        {
            return;
        }
            
        rightHandPose = rightHandState.GetJointPose(HandJointID.Palm);
        rightHandPointerPose = rightHandState.pointerPose;

        switch (rightHandState.currentGesture)
        {
            case HandGesture.Point:
                break;
            case HandGesture.Grab:
                 
                if(startPosition == new Vector3(0f,0f,0f))
                {
                    startPosition = rightHandPointerPose.position;
                }
                
                handPosition = rightHandPointerPose.position - startPosition;
                if(handPosition.x > 0.05f || handPosition.x < -0.05f)
                {
                    Vector3 newRotation = rover.transform.rotation.eulerAngles;
                    // only take the horizontal axis from the hand
                    newRotation.y += (handPosition.x * rotationSpeed);
                    newRotation.x = 0;
                    newRotation.z = 0;
                    rover.transform.localRotation = Quaternion.Euler(newRotation);
                }   
                break; 
            case HandGesture.Victory:
                break;
            case HandGesture.OpenHand:

                // if the rover touch a rock it's bounced back
                if((collider.stop) == true)
                {
                    transform.Translate(0, 0, 3 * Time.deltaTime * 50.01f);
                    (collider.stop) = false;
                }
                
                transform.Translate(-rover.transform.forward * Time.deltaTime * 50); //velocity of movement of the ground

                break;   
            default:
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
                time.isPause();

                break;
            default:
                break;
        }
       
    }

    //Method used to reset the position of the ground at the beginning, when I click on restart on the menus
    public void ResetPosition()
    {
        transform.position = pos;
    }
}