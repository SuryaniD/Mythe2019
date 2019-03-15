using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AISpotting : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Alerted,
        Searching,
        Following,
        Attacking
    }

    public AIState aiCurrentState = AIState.Idle;

    public float maxRange = 10f;
    public float currentRange = 10f;
    public float aiFov = 90f;
    public float timeSearching = 5f;


    [SerializeField]
    private string targetTag = "Player";
    private GameObject targetObject = null;

    [SerializeField]
    private bool debug = false;


    private Text debugText;

    void Start()
    {
        if (debug)
            DebugSetUp();

        targetObject = GameObject.FindGameObjectWithTag(targetTag);

        CheckState();
    }

    public void DebugSetUp()
    {
        GameObject _newChild = Instantiate((GameObject)Resources.Load("Debug/Text/Debug_Text")) as GameObject;
        _newChild.transform.SetParent(transform);
        _newChild.transform.position = transform.position;

        debugText = _newChild.transform.GetChild(0).GetComponent<Text>();
    }

    void FixedUpdate()
    {
        //Check the current state
        CheckState();

        //Check the current range between the target
        currentRange = CheckDistanceToObj(targetObject.transform.position);
    }

    
    public AIState CheckState()
    {

        switch (aiCurrentState)
        {
            case AIState.Idle:
                StateIdle();
            break;

            case AIState.Alerted:
                StateAlerted();
            break;

            case AIState.Searching:
                StateSearching();
            break;

            case AIState.Following:

            break;

            case AIState.Attacking:
                
            break;
        }


        return aiCurrentState;
    }


    public void SetCurrentState(AIState _value)
    {
        aiCurrentState = _value;

        switch (aiCurrentState)
        {
            case AIState.Idle:
                debugText.text = "Idle";
                break;

            case AIState.Alerted:
                debugText.text = "!";
                break;

            case AIState.Searching:
                debugText.text = "?";
                break;

            case AIState.Following:
                debugText.text = "Following";
                break;

            case AIState.Attacking:
                debugText.text = "Attacking";
                break;
        }
    }

    private bool Spotting(float _fovAngle)
    {
        Vector3 _pos = transform.position;

        bool _spotted = false;

        Vector3 _direction = targetObject.transform.position - _pos;
        float _angle = Vector3.Angle(_direction, transform.forward);


        if (_angle < aiFov * 0.5f)
        {
            RaycastHit _hit;

            if (Physics.Raycast(_pos + transform.up, _direction.normalized, out _hit))
            {
                if (_hit.collider.gameObject == targetObject)
                {
                    _spotted = true;
                }
            }

            Debug.DrawRay(transform.position, _direction * maxRange, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, _direction * maxRange, Color.red);
        }


        return _spotted;

    }

    private Vector3 ClampSpotting()
    {
        Vector3 _direction;

        _direction = Vector3.RotateTowards(transform.position, targetObject.transform.position, 1f, 0f);
        

        return _direction;
    }


    //-------------------------
    //-----State functions-----
    //-------------------------

    private void StateIdle()
    {
        if (Spotting(aiFov))
            SetCurrentState(AIState.Alerted);
    }

    private void StateAlerted()
    {
        if (!Spotting(aiFov))
            SetCurrentState(AIState.Idle);
    }

    private void StateSearching()
    {
        AlertedCountDown(timeSearching);
    }


    //-------------------------------
    //-----Gizmos draw functions-----
    //-------------------------------

    void OnDrawGizmos()
    {
        Vector3 _pos = transform.position;

        //Gizmos.DrawLine(_pos, targetObject.transform.position);

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, currentRange);

        //- Draw fov -
        Vector3 _dirL = Rotate(new Vector3(0f, aiFov * .5f, 0f));
        Vector3 _dirR = Rotate(new Vector3(0f, -aiFov * .5f, 0f));

        //Left
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawLine(_pos, _pos + _dirL * currentRange);
        //Right
        UnityEditor.Handles.DrawLine(_pos, _pos + _dirR * currentRange);

        //Right
        //Gizmos.DrawLine(_pos, targetObject.transform.position);
    }


    Vector3 Rotate(Vector3 _value)
    {
        return (Quaternion.Euler(_value) * transform.forward);
    }






    private float CheckDistanceToObj(Vector3 _position)
    {
        float _distance = Vector3.Distance(transform.position, _position);

        return _distance;
    }


    IEnumerator AlertedCountDown(float _time)
    {
        for (int i = 0; i < _time; i++)
        {
            if (i == _time)
                SetCurrentState(AIState.Idle);

            yield return new WaitForSeconds(i);
        }
    }

}
