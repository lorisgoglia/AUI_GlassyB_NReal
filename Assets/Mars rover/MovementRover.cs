using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NRKernal.NRExamples;
using NRKernal;

public class MovementRover : MonoBehaviour
{

    //private bool activeGo = false;
    //private bool activeRight = false;
    //private bool activeLeft = false;
    //private bool activeBack = false;
    private Pose rightHandPose;
    private Pose rightHandPointerPose;
    public Collider1 collider;
    private Vector3 pos;
    public GameObject rover;
    public float rotationSpeed = 10.0f;
    private Vector3 startPosition = new Vector3(0f,0f,0f);
    private Vector3 handPosition;
    private Rigidbody rigid;
    private bool go = false;
    private Vector3 newPosition;
    private Vector3 oldPosition;


    //private bool stop = false;
    //private Pose leftHandPose;
    //private Pose leftHandPointerPose;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rigid = GetComponent<Rigidbody>();
        //newPosition = transform.forward;
        //oldPosition = newPosition;
        //transform.position = newPosition;
       // oldPosition = transform.position;

    }

    // This script allows the movement of the ground relative to the rover with hand gestures
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
                    // only take the horizontal axis from the joystick
                    newRotation.y += (handPosition.x * rotationSpeed);
                    newRotation.x = 0;
                    newRotation.z = 0;
                    rover.transform.localRotation = Quaternion.Euler(newRotation);
                }   
                break; 
            case HandGesture.Victory:
                break;
            case HandGesture.OpenHand:

                //go = true;
                //rigid.velocity = transform.forward * rotationSpeed;
                
                
                if((collider.stop) == true)
                {
                    transform.Translate(0, 0, 10);
                    (collider.stop) = false;
                }
                //Quaternion rot = transform.rotation;
                //rot.y = rightHandPointerPose.rotation.y;
                //transform.rotation = rot;
                transform.Translate(-rover.transform.forward * Time.deltaTime * 6);
                    //rigid.velocity = rover.transform.forward * rotationSpeed;
                   // vector = new Vector3(rover.transform,position.x, 0, rover.transform.position.z);
                    //transform.Translate(0, 0, Time.deltaTime  * -1);
                    
               //go = false;
               
                
                //transform.RotateAround(rover.transform.position, rightHandPointerPose.up, rotationSpeed * Time.deltaTime);


                //transform.RotateAround(transform.position, transform.up, -1 * Time.deltaTime);
                //gameObject.transform.rotation = (rightHandPointerPose.rotation);
                break;   
            default:
                break;
        }
       
        

        //rightHandPose = rightHandState.GetJointPose(HandJointID.Palm);
        //rightHandPointerPose = rightHandState.pointerPose;
        //ground.transform.rotation = rightHandPointerPose.rotation;
        //laser.transform.SetPositionAndRotation(rightHandPose.position, rightHandPointerPose.rotation);

    
    }

    public void ResetPosition()
    {
        transform.position = pos;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            stop = true;
        }
        
    }*/

   /* public void Go(bool activeGo)
    {
        if(activeGo == true)
        {
            gameObject.transform.Translate(0, Terrain.activeTerrain.SampleHeight(transform.position), -150 * Time.deltaTime);
        }
        activeGo = false;
    
    }

    public void TurnRight(bool activeRight)
    {
        if(activeRight == true)
        {
            gameObject.transform.Rotate(0, -80 * 0.5f , 0);
        }
        activeRight = false;
    }

    public void TurnLeft(bool activeLeft)
    {
        if(activeLeft == true)
        {
            gameObject.transform.Rotate(0, 80 * 0.5f , 0);
        }
        activeLeft = false;
    }

    public void GoBack(bool activeBack)
    {
        if(activeBack == true)
        {
            gameObject.transform.Translate(0, Terrain.activeTerrain.SampleHeight(transform.position), 150 * Time.deltaTime);
        }
        activeBack = false;
    
    }*/
}
