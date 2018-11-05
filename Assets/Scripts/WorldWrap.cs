using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrap : MonoBehaviour {

    public float minimumX;
    public float maximumX;
    public float minimumZ;
    public float maximumZ;

    private void OnTriggerExit(Collider other)
    {
        Vector3 temp = other.transform.position;

        if(temp.x < minimumX || temp.x > maximumX)
        {
            //wrap horizontally
            temp.x *= -1;
        }

        if(temp.z < minimumZ || temp.z > maximumZ)
        {
            //wrap vertically
            temp.z *= -1;
        }

        other.transform.position = temp;
    }
}
