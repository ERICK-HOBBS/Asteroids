using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        // teleport game object
        if (transform.position.x > 23.8)
        {

            transform.position = new Vector3(-23.8f, transform.position.y, 0);

        }
        else if (transform.position.x < -23.8)
        {
            transform.position = new Vector3(23.8f, transform.position.y, 0);
        }

        else if (transform.position.y > 10.2)
        {
            transform.position = new Vector3(transform.position.x, -10.2f, 0);
        }

        else if (transform.position.y < -10.2)
        {
            transform.position = new Vector3(transform.position.x, 10.2f, 0);
        }
    }
}