using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public string playerTag = "player";
    public Vector3 resetPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            other.transform.position = resetPos;
        }
    }
}
