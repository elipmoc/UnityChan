﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour {

    //移動先リスト
    [SerializeField]
    List<Transform> movePoints;
    [SerializeField]
    float speed;

    [SerializeField]
    int waitTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(Move().GetEnumerator());
	}
	
    IEnumerable Move()
    {
        while (true)
        {
            foreach (var point in movePoints)
            {

                yield return new WaitForSeconds(waitTime);

                while ((point.transform.position - transform.position).magnitude > speed*Time.deltaTime)
                {
                    transform.position+= (point.transform.position - transform.position).normalized * speed*Time.deltaTime;
                    yield return null;
                }

            }

        }
    }
}
