using UnityEngine;
using System.Collections;

public class AITurnTo : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;

        float _y = direction.y;

        direction.y = direction.z;

        direction.z = -_y;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation.z = rotation.y;
        rotation.y = 0;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, speed * Time.deltaTime);
    }
}