using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToObj : MonoBehaviour
{

    //make sure to add logic for when it is picked up and make it nog bug with the scaling 
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.parent = collision.transform;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        gameObject.transform.rotation = collision.transform.rotation;
    }

    private void OnCollisionStay(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    private void OnCollisionExit(Collision collision)
    {
        gameObject.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
