using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HandToTrack
{
    Left, 
    Right
}

public class MoveHand : MonoBehaviour
{

    [SerializeField]
    private HandToTrack handToTrack = HandToTrack.Left;
    
    [SerializeField]
    private GameObject objectToTrackMovement;

    [SerializeField]
    private float minFingerPinchStrength = 0.5f;
    
    // For debugging mainly 
    // [SerializeField]
    // private GameObject editorObjectToTrackMovement; 

    private bool IsPinchingDown = false;

    private OVRHand ovrHand; 

    private OVRSkeleton ovrSkeleton;

    private OVRBone boneToTrack; 

    public MoveMapWithGestures moveCube;
    public MoveMapWithGestures moveMap;


    void Awake()
    {
        ovrHand = objectToTrackMovement.GetComponent<OVRHand>();
        ovrSkeleton = objectToTrackMovement.GetComponent<OVRSkeleton>();

        for (int i = 0; i < ovrSkeleton.Bones.Count; i++)
        {
            if (ovrSkeleton.Bones[i].Id == OVRSkeleton.BoneId.Hand_Index1) 
            {
                boneToTrack = ovrSkeleton.Bones[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boneToTrack == null)
        {            
            for (int i = 0; i < ovrSkeleton.Bones.Count; i++)
            {
                if (ovrSkeleton.Bones[i].Id == OVRSkeleton.BoneId.Hand_Index3) 
                {
                    boneToTrack = ovrSkeleton.Bones[i];
                }
            }

            objectToTrackMovement = boneToTrack.Transform.gameObject;
        }
        CheckPinchState();
    }

    private void CheckPinchState()
    {
        bool isIndexFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        float indexFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

        bool isPinkyFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky);
        float pinkyFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky);

        bool isMiddleFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Middle);
        float middleFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Middle);

        bool isRingFingerPinching = ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Ring);
        float ringFingerPinchStrength = ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);

        if (isIndexFingerPinching && indexFingerPinchStrength > minFingerPinchStrength) 
        {
            IsPinchingDown = false;
            // move cube from here 
            moveCube.moveCube("forward");
            moveMap.moveCube("forward");

        }
        else if (isMiddleFingerPinching && middleFingerPinchStrength > minFingerPinchStrength)
        {
            IsPinchingDown = false;
            // move cube from here 
            moveCube.moveCube("backward");
            moveMap.moveCube("backward");
        }
         else if (isRingFingerPinching && ringFingerPinchStrength > minFingerPinchStrength)
        {
            IsPinchingDown = false;
            // move cube from here 
            moveCube.moveCube("left");
            moveMap.moveCube("left");
        }
        else if (isPinkyFingerPinching && pinkyFingerPinchStrength > minFingerPinchStrength)
        {
            IsPinchingDown = false;
            // move cube from here 
            moveCube.moveCube("right");
            moveMap.moveCube("right");
        }
        else
        {
            if (!IsPinchingDown)
            {
                IsPinchingDown = true;
            }
        } 
    }
}
