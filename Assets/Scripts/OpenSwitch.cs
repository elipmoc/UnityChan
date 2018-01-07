using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSwitch : PlayerActionReceiver {
    [SerializeField]
    private Renderer renderer;
    [SerializeField]
    private Transform moveObject;
    private bool flag = false;
    private float move = 15;
    private float moveSpeed=0.01f;
	// Use this for initialization
	void Start () {
        renderer.material.color=Color.green;
	}

    public override void OnAction()
    {
        if (flag == false)
        {
            renderer.material.color = Color.yellow;
            flag = true;
            StartCoroutine(Move().GetEnumerator());
        }
    }

    private IEnumerable Move()
    {
        while (move > 0)
        {
            moveObject.Translate(0, -moveSpeed, 0);
            move -= moveSpeed;
            yield return null;
        }
    }

}
