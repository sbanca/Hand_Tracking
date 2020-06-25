using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using OVRTouchSample;
using Oculus;


public class MoveMapWithGestures : MonoBehaviour
{
    // Movements based on camera rotation at (0,0,0)
    public void moveCube(string direction)
    {
        if (direction == "forward")
        {
            transform.Translate(0, 0, 1);
        }

        if (direction == "backward")
        { 
            transform.Translate(0, 0, -1);  
        }

        if (direction == "right")
        {
            transform.Translate(1, 0, 0);
        }

        if (direction == "left")
        {
            transform.Translate(-1, 0, 0);
        }
        // // Moves right
        // // Moves left
        // transform.Translate(-1, 0, 0);

    }
}
