using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform target;
    public float speed = 3f;


    void Start()
    {

    }

    void Update()
    {

        
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

}
