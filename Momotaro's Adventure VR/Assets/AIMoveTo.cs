using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIMoveTo : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    [Header("Target to go to")]
    [SerializeField]
    private string targetTag = "Enemy";

    [SerializeField]
    private bool debug = false;

    Transform target;

    void Start()
    {
        if (debug)
            SearchTarget(targetTag);
    }

    void Update()
    {
        if (debug)
            MoveTo(target.position, movementSpeed);
    }

    /// <summary>
    /// Searches for the target
    /// </summary>
    /// <param name="_tag"></param>
    public void SearchTarget(string _tag)
    {
        target = GameObject.FindGameObjectWithTag(_tag).transform;
    }

    /// <summary>
    /// Move towards target
    /// </summary>
    /// <param name="_target">The target to move to</param>
    /// <param name="_speed"></param>
    public void MoveTo(Vector3 _target, float _speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

}
