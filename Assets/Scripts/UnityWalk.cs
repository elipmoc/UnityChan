using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityWalk : MonoBehaviour {

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float movePower ;
    [SerializeField]
    private float jumpMoveFixed=0.5f;
    private Vector3 addMoveForce;
    [SerializeField]
    private Rigidbody rig;
    private bool groundFlag;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private CameraTarget cameraTarget;
    private Vector3 restartPosition;
    private bool jumpFlag=false;
    [SerializeField]
    private float jumpForce;

    private Transform defaultParent;
    private Vector3 defaultScale;

    // Use this for initialization
    void Start () {
        restartPosition = transform.position;
        defaultParent = transform.parent;
        defaultScale = transform.localScale;
	}

    private void Update()
    {
        addMoveForce = Vector3.zero;
        var vec3 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (groundFlag)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
            }
            if (jumpFlag == false && Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Shagamu", true);
            }
            else
                animator.SetBool("Shagamu", false);

        }
        if (vec3.magnitude > float.Epsilon)
        {
            vec3 = cameraTarget.Angle * vec3;
            transform.forward = vec3;
            if(jumpFlag)
                addMoveForce = vec3 * movePower*jumpMoveFixed;
            else
                addMoveForce = vec3 * movePower;
        }



        Vector2 XZVelocity = new Vector2(rig.velocity.x, rig.velocity.z);
        animator.SetFloat("Speed", XZVelocity.magnitude);

        if (transform.position.y < -100)
        {
            transform.position = restartPosition;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + new Vector3(0, 0.3F, 0), new Vector3(0.5F, 0.2f, 0.5F));
    }

    // Update is called once per frame
    void FixedUpdate () {

        RaycastHit rayhit;
        var hit = Physics.BoxCast(transform.position+new Vector3(0,0.3F,0), new Vector3(0.5F, 0.2f, 0.5F), Vector3.down, out rayhit, Quaternion.identity, groundDistance);
        if (hit)
        {
            groundFlag = true;
        }
        else
            groundFlag = false;
        rig.AddForce(addMoveForce);
       


    }

    void OnJump()
    {
        animator.SetBool("Jump", false);

        rig.AddForce(new Vector3(0, jumpForce, 0)+transform.forward, ForceMode.Impulse);
    }

    void OnJumpStart()
    {
        jumpFlag = true;
    }

    void OnJumpEnd()
    {
        jumpFlag = false;
        animator.SetBool("Jump", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MoveStage")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MoveStage" && collision.gameObject.GetInstanceID()==transform.parent.gameObject.GetInstanceID())
        {
            transform.SetParent(defaultParent);
            transform.localScale = defaultScale;
        }
    }
}
