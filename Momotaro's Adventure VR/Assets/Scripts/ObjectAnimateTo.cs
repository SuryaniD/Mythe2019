using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectAnimateTo : MonoBehaviour
{
    [SerializeField]
    private bool showEndPoint = false;

    [SerializeField]
    private Vector3 startPoint;

    [SerializeField]
    private Vector3 endPoint;

    [SerializeField]
    private Vector3 lockAxes = new Vector3(1, 1, 1);


    public bool debugAnimate = false;

    void Start()
    {
        startPoint = transform.position;
        LockAxes(lockAxes);
    }

    void FixedUpdate()
    {
        if (AnimateToEndPoint())
            return;

    }

    public void LockAxes(Vector3 _axes)
    {

    }


    public bool AnimateToPosition(Vector3 _position, float _speed)
    {
        bool _return = false;

        _position.x = lockAxes.x * _position.x;
        _position.y = lockAxes.y * _position.y;
        _position.z = lockAxes.z * _position.z;

        if (Vector3.Distance(transform.position, _position) <= 0)
            _return = true;
        else
            transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.deltaTime);

        return _return;
    }

    /// <summary>
    /// Translates the object to the startpoint (Call this for use outside this script)
    /// </summary>
    /// <returns></returns>
    public bool AnimateToStartPoint()
    {
        bool _return = false;

        if (AnimateToPosition(startPoint, 2f))
            _return = true;

        return _return;
    }

    /// <summary>
    /// Translates the object to the endpoint (Call this for use outside this script)
    /// </summary>
    /// <returns></returns>
    public bool AnimateToEndPoint()
    {
        bool _return = false;

        if (AnimateToPosition(endPoint, 2f))
            _return = true;

        return _return;
    }

    void OnDrawGizmos()
    {
        if (showEndPoint)
        {
            Vector3 boxCollider = GetComponent<BoxCollider>().bounds.size;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(endPoint, new Vector3(1, 1, 1));
            //UnityEditor.Handles.Draw
        }
    }
}





/*[SerializeField]
    private bool showEndPoint = false;

    public Transform endPoint = null;

    public bool debugAnimate = false;


    void FixedUpdate()
    {
        if (endPoint == null)
        {
            GameObject _inst = Instantiate(new GameObject("EndPoint"));
            endPoint = _inst.transform;
        }

        if (debugAnimate)
            if (AnimateToPosition())
            {

            }
    }


    public bool AnimateToPosition()
    {
        bool _return = false;

        transform.Translate(endPoint.position * Time.deltaTime);

        if (Vector3.Distance(transform.position, endPoint.position) <= 0)
        {
            _return = true;
        }

        return _return;
    }
    
    void OnDrawGizmos()
    {
        if (showEndPoint)
        {
            Vector3 boxCollider = GetComponent<BoxCollider>().bounds.size;
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(endPoint.position, boxCollider);
        }
        
    }*/
