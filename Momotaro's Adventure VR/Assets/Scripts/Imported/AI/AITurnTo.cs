using UnityEngine;
using System.Collections;

public class AITurnTo : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    public Vector3 rotationSpeedScale = new Vector3(1, 1, 1);

    private void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        TurnToTransform(target);
    }

    public void TurnToTransform(Transform _transform)
    {
        Vector3 direction = _transform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation.x = rotation.x * rotationSpeedScale.x;
        rotation.y = rotation.y * rotationSpeedScale.y;
        rotation.z = rotation.z * rotationSpeedScale.z;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, speed * Time.deltaTime);
    }
}