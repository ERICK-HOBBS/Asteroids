/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    float timer = 0;
    public GameObject newObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        float range = Random.Range(-10, 10);

        Vector3 newPosition = new Vector3(GameObject.Find("Player").transform.position.x + range, transform.position.y, 0);
        if (timer >= 1)
        {
            GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            timer = 0;
        }
	}
}/*
*/////