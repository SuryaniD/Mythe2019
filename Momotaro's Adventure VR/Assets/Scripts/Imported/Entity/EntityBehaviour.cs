using System;
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

    //- Shared variables -

    //-Target
    public string targetTag = "Player";
    public GameObject targetObject = null;
    public float aiFov = 130f;
    //Ranges
    public float targetRangeToAttack = 2f;// The range between the position and to target before AI can attack
    public float targetRangeCurrent = 2f;// The current range to the target


    //-Moving
    public float moveSpeed = 2f;
    public NavMeshAgent navAgent;

    //-Delegates
    //public Action entityAttack;
    public EnemyAttack enemyAttack;
    public AIMoveTo aiMoveTo;

    
    //--------------------------------------------------------------------------


    public bool debug = false;


    private Text debugText;


    void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        aiMoveTo = GetComponent<AIMoveTo>();
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        
        healthCurrent = 100f;

        if (debug)
            DebugSetUp();

        

        CheckState();

        //entityAttack();
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

    //---------------
    //-----State-----
    //---------------

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
                StateIdle();
                break;

            case AIState.Alerted:
                StateAlerted();
                break;

            case AIState.Searching:
                StateSearching();
                break;

            case AIState.Following:
                StateFollowing();
                break;

            case AIState.Attacking:
                StateAttacking();
                break;
        }

        return aiStateCurrent;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="_value"></param>
    /// <returns></returns>
    public Vector3 RotateToDirection(Vector3 _value)
    {
        return (Quaternion.Euler(_value) * transform.forward);
    }

    //-------------------------
    //-----State functions-----
    //-------------------------

    #region State Functions
    public virtual void StateIdle()
    {
        if (targetRangeCurrent < targetRangeToAttack)
            SetCurrentState(AIState.Attacking);
        else
            SetCurrentState(AIState.Following);
    }

    public virtual void StateAlerted()
    {
        
    }

    public virtual void StateSearching()
    {
        
    }

    public virtual void StateFollowing()
    {
        if (targetRangeCurrent > targetRangeToAttack)
            aiMoveTo.MoveTo(targetObject.transform.position, moveSpeed, targetRangeToAttack * 0.6f);
        else
            SetCurrentState(AIState.Attacking);
    }

    public virtual void StateAttacking()
    {
        if (targetRangeCurrent < targetRangeToAttack)
            enemyAttack.Attack();
        else
            SetCurrentState(AIState.Following);
    }
    #endregion

    /// <summary>
    /// Checks the distance to an object
    /// </summary>
    /// <param name="_position"></param>
    /// <returns></returns>
    public float CheckDistanceToObj(Vector3 _position)
    {
        float _distance = Vector3.Distance(transform.position, _position);

        return _distance;
    }


    public void OnDrawGizmos()//visual for minimum attack range
    {
        //Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, minAttackRange);


        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, targetRangeToAttack);
    }
}

