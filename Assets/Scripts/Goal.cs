using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync("Goal");   
    }

    // Update is called once per frame
    void Update () {
		
	}
}
