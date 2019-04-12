using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLoop : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        Move();
    }

    public void Move()
    {

        transform.position += new Vector3(1,0,0) * Time.deltaTime * speed;
    }
}
