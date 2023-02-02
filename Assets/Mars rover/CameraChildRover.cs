using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildRover : MonoBehaviour
{
   public Transform parentTransform;
 
     // If true, will attempt to scale the child accurately as the parent scales
     // Will not be accurate if starting rotations are different or irregular
     // Experimental
     public bool attemptChildScale = false;
 
     Vector3 startParentPosition;
     Quaternion startParentRotationQ;
     Vector3 startParentScale;
 
     Vector3 startChildPosition;
     Quaternion startChildRotationQ;
     Vector3 startChildScale;
 
     Matrix4x4 parentMatrix;
 
     void Start () 
     {
 
         startParentPosition = parentTransform.position;
         startParentRotationQ = parentTransform.rotation;
         startParentScale = parentTransform.lossyScale;
 
         startChildPosition = transform.position;
         startChildRotationQ = transform.rotation;
         startChildScale = transform.lossyScale;
 
         // Keeps child position from being modified at the start by the parent's initial transform
         startChildPosition = DivideVectors(Quaternion.Inverse(parentTransform.rotation) * (startChildPosition - startParentPosition), startParentScale);
     }
     
     void Update () 
     {
         
         parentMatrix = Matrix4x4.TRS(parentTransform.position, parentTransform.rotation, parentTransform.lossyScale);
 
         transform.position = parentMatrix.MultiplyPoint3x4(startChildPosition);
 
         transform.rotation = (parentTransform.rotation * Quaternion.Inverse(startParentRotationQ)) * startChildRotationQ;
 
         // Incorrect scale code; it scales the child locally not gloabally; Might work in some cases, but will be inaccurate in others
         if (attemptChildScale) 
         {
             transform.localScale = Vector3.Scale(startChildScale, DivideVectors(parentTransform.lossyScale, startParentScale));
         }
 
         
     }
 
    Vector3 DivideVectors(Vector3 num, Vector3 den) 
    {
 
         return new Vector3(num.x / den.x, num.y / den.y, num.z / den.z);
 
    }
 
}
