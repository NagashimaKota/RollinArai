using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freez : MonoBehaviour {

    private backMove backmove;
    
    // Use this for initialization
	void Start () {
        backmove = GameObject.Find("BacGround").GetComponent<backMove>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D pl)
    {
        
        if (pl.gameObject.tag == "Player")
        {
            backmove.Swich();
        }
        
    }
}
