using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DetectSide : MonoBehaviour {

    [SerializeField]
    private BaseDetectCube detectCube;
    private int detectCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(detectCount==0)
            detectCube.On();
        detectCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        detectCount--;
        if(detectCount==0)
            detectCube.Off();
    }

}
