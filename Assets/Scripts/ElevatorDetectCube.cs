using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDetectCube : BaseDetectCube {

    [SerializeField]
    private int height;
    private float baseHeight;
    private bool moveUpFlag = false;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Rigidbody rig;

    private void Start()
    {
        baseHeight = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (moveUpFlag)
        {
            if(rig.position.y < height+baseHeight)
            {
                rig.position += new Vector3(0, moveSpeed, 0);
            }
        }
        else
        {
            if(rig.position.y > baseHeight)
            {
                rig.position += new Vector3(0, -moveSpeed, 0);
            }
        }

    }

    public override void On()
    {
        base.On();
        moveUpFlag = true;
    }

    public override void Off()
    {
        base.Off();
        moveUpFlag = false;
    }
}
