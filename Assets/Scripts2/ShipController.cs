using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float rotationSpeed = 100.0f;
    public float thrustForce = 3f;

    public AudioClip crash;
    public AudioClip shoot;

    public GameObject bullet;

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        gameController = gameControllerObject.GetComponent<GameController>();
    }

    void FixedUpdate()
    {

        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        GetComponent<Rigidbody2D>(). AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));

        if (Input.GetKeyDown("space"))
        {
            ShootBullet();
        }
            

    }

    void OnTriggerEnter2D(Collider2D c)
    {

        if (c.gameObject.tag != "Bullet")
        {

            AudioSource.PlayClipAtPoint(crash, Camera.main.transform.position);

            // move ship to the centre of screen
            transform.position = new Vector3(0, 0, 0);

            // remove velocity from ship
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

            gameController.DecrementLives();
        }
    }

    void ShootBullet()
    {

        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }
}
