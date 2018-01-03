using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [SerializeField]
    private  Rigidbody rig;
    private Vector3 vec3;
    private readonly float movePower=70;
    private bool groundFlag;
    [SerializeField]
    private float groundDistance;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vec3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
    }

    private void OnDrawGizmos()
    {

    }

    void FixedUpdate()
    {
        RaycastHit rayhit;
        var hit = Physics.BoxCast(transform.position, new Vector3(1, 0.5f, 1), Vector3.down, out rayhit,Quaternion.identity, groundDistance);
        if (hit)
        {
         //   rig.position=new Vector3(rig.position.x, rayhit.point.y+1,rig.position.z);
            groundFlag = true;
        }

        if (groundFlag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector3(0, 35, 0), ForceMode.Impulse);
            }
            rig.AddForce(vec3 * movePower);
            groundFlag = false;
        }
    }
}


