/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal.NRExamples;
using NRKernal;


public class RoverGesture : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private bool isOpen;
    private Pose rightHandPose;
    private Pose rightHandPointerPose;
   

    /*
    private void Start()
    {
        StartCoroutine(LaserDeactivator());
    }
    

    IEnumerator LaserDeactivator()
    {
        if (!isOpen)
        {
            laser.SetActive(true);
            //SoundManagerScript.PlaySound("beam");
            yield return new WaitForSeconds(3);
            laser.SetActive(false);
        }
    }

    private void Update()
    {
        HandState rightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        if (rightHandState == null)
            return;

        switch (rightHandState.currentGesture)
        {
            case HandGesture.Point:
                break;
            case HandGesture.Grab:
                //laser.GetComponent<MeshRenderer>().enabled = false;
                isOpen = false;
                //SoundManagerScript.PlaySound("reloading");
                laser.SetActive(false);
                break; 
            case HandGesture.Victory:
                break;
            case HandGesture.OpenHand:
                //laser.SetActive(true);
                StartCoroutine(LaserDeactivator());
                isOpen = true;
                //laser.GetComponent<MeshRenderer>().enabled = true;
                break;
            default:
                //laser.GetComponent<MeshRenderer>().enabled = false;
                laser.SetActive(false);
                break;
        }

        //Questa parte serve a gestire il movimento del laser
        rightHandPose = rightHandState.GetJointPose(HandJointID.Palm);
        rightHandPointerPose = rightHandState.pointerPose;
        laser.transform.SetPositionAndRotation(rightHandPose.position, rightHandPointerPose.rotation);
    }
}
*/