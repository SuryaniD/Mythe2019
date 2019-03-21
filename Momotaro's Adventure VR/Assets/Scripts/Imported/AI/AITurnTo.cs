using UnityEngine;
using System.Collections;

public class AITurnTo : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    public Vector3 rotationSpeedScale = new Vector3(1, 1, 1);

    private void Update()
    {
        Vector3 direction = target.position - transform.position;

        //float _y = direction.y;

        //direction.y = direction.z;

        //direction.z = -_y;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation.x = rotation.x * rotationSpeedScale.x;
        rotation.y = rotation.y * rotationSpeedScale.y;
        rotation.z = rotation.z * rotationSpeedScale.z;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, speed * Time.deltaTime);
    }
}