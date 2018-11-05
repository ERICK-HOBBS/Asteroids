using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag =="target")
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
