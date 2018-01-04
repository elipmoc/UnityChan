using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//playerが何らかのオブジェクトに対してアクションが行える時、そのアクションができることを画面に表示する
public class PlayerActionGUI : MonoBehaviour {
    [SerializeField]
    private GameObject image;
    private GameObject actionObject=null;

	// Update is called once per frame
	void Update () {
		if(actionObject!=null&& Input.GetKeyDown(KeyCode.F))
        {
            actionObject.GetComponent<PlayerActionReceiver>().OnAction();
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerActionObject")
        {
            actionObject = collision.gameObject;
            image.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerActionObject")
        {
            actionObject = null;
            image.SetActive(false);
        }
    }

}
