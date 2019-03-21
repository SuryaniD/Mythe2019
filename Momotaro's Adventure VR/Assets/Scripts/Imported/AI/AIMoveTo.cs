using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Peerprogrammed by Eva Hoefs & Peter Schreuder. 2019.
/// </summary>

public class AIMoveTo : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f, maxDistanceBetween = 4f;


    private string targetTag = "Player";
    Transform target = null;
    private bool debug = true;

    public Vector3 lockScale = new Vector3(1, 1, 1);


    void Update()
    {
        if (debug)
        {
            if (target == null)
                SearchTarget(targetTag);

            if (target != null)
                MoveTo(target.position, moveSpeed, maxDistanceBetween);
        }
    }

    /// <summary>
    /// Searches for the target
    /// </summary>
    /// <param name="_tag"></param>
    public bool SearchTarget(string _tag)
    {
        bool _return = false;
        GameObject _target = GameObject.FindGameObjectWithTag(_tag);


        if (_target == null)
            Debug.Log("No target found! (Initialized)");
        else
        {
            target = _target.transform;
            _return = true;
        }
            

        return _return;
    }

    /// <summary>
    /// Move towards target
    /// </summary>
    /// <param name="_target">The target to move to</param>
    /// <param name="_speed"></param>
    public bool MoveTo(Vector3 _target, float _speed, float _maxDistanceBetween)
    {
        Vector3 _pos = transform.position;
        Vector3 _newPos = new Vector3(_pos.x * lockScale.x, _pos.y * lockScale.y, _pos.z * lockScale.z);

        bool _return = false;
        float _distance = Vector3.Distance(_newPos, _target);

        if (_distance > _maxDistanceBetween)
            transform.position = Vector3.MoveTowards(_newPos, _target, _speed * Time.deltaTime);
        else
            _return = true;

        return _return;
    }
}
