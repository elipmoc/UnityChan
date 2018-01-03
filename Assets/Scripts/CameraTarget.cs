using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    [SerializeField]
    private Transform targetPos;
    [SerializeField]
    private float cameraRotateSpeed;
    private Vector3 offset;
    private Quaternion angle=Quaternion.identity;
    public Quaternion Angle { get { return angle; } }

	// Use this for initialization
	void Start () {
        offset= transform.position - targetPos.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            angle *= Quaternion.AngleAxis(-cameraRotateSpeed * Time.deltaTime, Vector3.up);
            transform.rotation= Quaternion.AngleAxis(-cameraRotateSpeed * Time.deltaTime, Vector3.up)*transform.rotation;
        }
        if (Input.GetKey(KeyCode.E))
        {
            angle *= Quaternion.AngleAxis(cameraRotateSpeed * Time.deltaTime, Vector3.up);
            transform.rotation= Quaternion.AngleAxis(cameraRotateSpeed * Time.deltaTime, Vector3.up)*transform.rotation;
        }
        transform.position= targetPos.position + angle*offset;
	}
}
