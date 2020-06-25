using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognised; 

}

public class GestureDetector : MonoBehaviour
{

    public float threshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    public bool debugMode = true; 
    private Gesture previousGesture;


    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {

        //if (debugMode)
        //{
        //    save();
        //}

        //Gesture currentGesture = Recognise();
        //bool hasRecognised = !currentGesture.Equals(new Gesture());
        //// Check if new gesture 
        //if (hasRecognised && !currentGesture.Equals(previousGesture))
        //{
        //    // new gesture 
        //    Debug.Log("New gesture found : " + currentGesture.name);
        //    previousGesture = currentGesture;
        //    currentGesture.onRecognised.Invoke();
        //}

    }

    void save()
    {
        Gesture g = new Gesture();
        g.name = "new gesture";
        List<Vector3> data = new List<Vector3>();
        Debug.Log("New gesture here");
        bool isNull = fingerBones == null;
        Debug.Log("Finger bones is null : " + isNull.ToString());
        int i = 0;
        foreach (var bone in fingerBones)
        {
            Debug.Log(i%fingerBones.Count);
            //looking at finger position relative to the root
            Vector3 val = skeleton.transform.InverseTransformPoint(bone.Transform.position);
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
           
            string value = val.ToString("F8");
            Debug.Log(value);
            i += 1;
        }
        // Debug.Log(data);
        g.fingerDatas = data;
        Debug.Log("End of gesture here");
        gestures.Add(g);

    }

    //Gesture Recognise()
    //{
    //    Gesture currentGest = new Gesture();
    //    float currentMin = Mathf.Infinity;
    //    foreach (var gesture in gestures)
    //    {
    //        float sumDistance = 0;
    //        bool isDiscarded = false;

    //        for (int i = 0; i < fingerBones.Count; i++)
    //        {
    //            Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
    //            float distance = Vector3.Distance(currentData, gesture.fingerDatas[i]);
    //            if (distance > threshold)
    //            {
    //                isDiscarded = true;
    //                break;
    //            }
    //            sumDistance += distance;
    //        }
    //        if (!isDiscarded && sumDistance < currentMin)
    //        {
    //            currentMin = sumDistance;
    //            currentGest = gesture;
    //        }
    //    }
    //    return currentGest;
    //}

}
