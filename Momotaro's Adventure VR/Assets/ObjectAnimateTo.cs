using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ObjectAnimateTo : MonoBehaviour
{
    

    void OnDrawGizmos()
    {
        Vector3 boxCollider = GetComponent<BoxCollider>().bounds.size;
        Gizmos.DrawCube(transform.position, boxCollider);
    }

}
