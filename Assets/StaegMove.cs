using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaegMove : MonoBehaviour {

    private Transform back1, back2, back3;

    // Use this for initialization
    void Start () {
        back1 = GameObject.Find("back1").GetComponent<Transform>();
        back2 = GameObject.Find("back2").GetComponent<Transform>();
        back3 = GameObject.Find("back3").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        
        /*
        if (moveSwich == true)
        {
            back1.Translate(speed, 0, 0);  //StageMove
            back2.Translate(speed, 0, 0);  //StageMove
            back3.Translate(speed, 0, 0);  //StageMove
        }
        else
        {
            time += Time.deltaTime;
        }
        */
    }
}
