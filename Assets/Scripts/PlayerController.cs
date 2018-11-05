using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;

    private Rigidbody2D rb;
    public float maxVelocity = 3;
    public float rotationSpeed = 3;

	// Use this for initialization
	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce(transform.up * 700f);
        }
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }
}
