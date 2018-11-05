using UnityEngine;
using System.Collections;

public class TurnOnCollision : MonoBehaviour 
{
	public float speed;
	
	void Start()
	{
		//start going in a random direction.
		GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range (-1f,1f),Random.Range(-1f,1f)) * speed;	
	}
	
	//Fixed Update is called once per physics frame
	void FixedUpdate () 
	{
		//face the direction we are moving.
		//transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody2D>().velocity);
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		//pick a new direction using a central circle of 10 radius. Ships will have a central tendancy this way.
        GetComponent<Rigidbody2D>().velocity = (new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f)) - transform.position);

        //make sure we don't go beyond our max speed in the new direction.
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * speed;
	}
}
