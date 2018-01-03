using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DetectSide : MonoBehaviour {

    [SerializeField]
    private BaseDetectCube detectCube;

    private void OnTriggerEnter(Collider other)
    {
        detectCube.On();
    }

    private void OnTriggerExit(Collider other)
    {
        detectCube.Off();
    }

}
