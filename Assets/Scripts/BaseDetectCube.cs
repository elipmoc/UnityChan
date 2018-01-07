using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDetectCube : MonoBehaviour {

    [SerializeField]
    private Material material;

    protected void Start()
    {
        material.color = Color.blue;
    }

    public virtual void On()
    {
        material.color = Color.red;
    } 

    public virtual void Off()
    {

        material.color =Color.blue;
    }

}
