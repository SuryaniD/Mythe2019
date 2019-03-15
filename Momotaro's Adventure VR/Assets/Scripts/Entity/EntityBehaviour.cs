using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EntityBehaviour : Entity
{
    public enum AIState
    {
        Idle,
        Alerted,
        Following,
        Attacking,
        Searching,
    }

    public AIState aiStateCurrent = AIState.Idle;

    [SerializeField]
    private string targetTag = "Player";
    private GameObject targetObject;

    [SerializeField]
    private float moveSpeed = 2f;

    public NavMeshAgent navAgent;

    private float targetRangeToAttack = 2f;
    private float targetRangeCurrent = 2f;
    //--------------------------------------------------------------------------



    [SerializeField]
    private bool debug = false;


    private Text debugText;


    void Start()
    {
        HealthCurrent = 100f;

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
        targetRangeCurrent = CheckDistanceToObj(targetObject.transform.position);
    }

    //--------
    //-----State
    //---------
    public void SetCurrentState(AIState _value)
    {
        aiStateCurrent = _value;

        switch (aiStateCurrent)
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

    public AIState CheckState()
    {

        switch (aiStateCurrent)
        {
            case AIState.Idle:
                //StateIdle();
                break;

            case AIState.Alerted:
                //StateAlerted();
                break;

            case AIState.Searching:
                //StateSearching();
                break;

            case AIState.Following:

                break;

            case AIState.Attacking:

                break;
        }

        return aiStateCurrent;
    }


    /// <summary>
    /// Checks the distance to an object
    /// </summary>
    /// <param name="_position"></param>
    /// <returns></returns>
    private float CheckDistanceToObj(Vector3 _position)
    {
        float _distance = Vector3.Distance(transform.position, _position);

        return _distance;
    }



}

