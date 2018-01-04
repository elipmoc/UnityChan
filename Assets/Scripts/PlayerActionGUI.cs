using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//playerが何らかのオブジェクトに対してアクションが行える時、そのアクションができることを画面に表示する
public class PlayerActionGUI : MonoBehaviour {
    [SerializeField]
    private GameObject image;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerActionObject")
        {
            image.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerActionObject")
        {
            image.SetActive(false);
        }
    }

}
