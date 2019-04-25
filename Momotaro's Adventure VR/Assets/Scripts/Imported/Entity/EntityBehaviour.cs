using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum AIState
{
    Idle = 0,
    Alerted,
    Following,
    Attacking,
    Searching,
    Dead,
}

public class EntityBehaviour : Entity
{
    
    
    public AIState aiStateCurrent = AIState.Idle;

    //- Shared variables -

    //-Target
    public string targetTag = "Player";
    public GameObject targetObject = null;
    private Entity targetBehaviour;
    public float aiFov = 130f;
    //Ranges+
    public float targetRangeToAttack = 3f;// The range between the position and to target before AI can attack
    public float targetRangeCurrent;// The current range to the target


    //-Moving
    public float moveSpeed = 2f;
    public NavMeshAgent navAgent;

    //-Delegates
    //public Action entityAttack;
    public EnemyAttack enemyAttack;
    public AIMoveTo aiMoveTo;

    public Action<float> moving;


    //--------------------------------------------------------------------------


    public bool debug = false;


    private Text debugText;


    void Start()
    {
        aiMoveTo = GetComponent<AIMoveTo>();
        targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null)
            targetBehaviour = targetObject.GetComponent<Entity>();

        enemyAttack = GetComponent<EnemyAttack>();
        
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

        CheckHealthState();
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
              //  debugText.text = "Idle";
                break;

            case AIState.Alerted:
             //   debugText.text = "!";
                break;

            case AIState.Searching:
             //   debugText.text = "?";
                break;

            case AIState.Following:
             //   debugText.text = "Following";
                break;

            case AIState.Attacking:
 
                break;

            case AIState.Dead:
               // debugText.text = "Dead";
                break;
        }
    }

    public AIState CheckState()
    {
        if (entityStateCurrent != EntityStates.Dead)
        {
            switch (aiStateCurrent)
            {
                case AIState.Idle:
                    StateDefault();
                    StateIdle();
                    break;

                case AIState.Alerted:
                    StateDefault();
                    StateAlerted();
                    break;

                case AIState.Searching:
                    StateDefault();
                    StateSearching();
                    break;

                case AIState.Following:
                    StateDefault();
                    StateFollowing();
                    break;

                case AIState.Attacking:
                    StateDefault();
                    StateAttacking();
                    break;

                case AIState.Dead:
                    StateDefault();
                    StateDead2();
                    break;
            }
        }
        else
        {
            StateDead2();
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
    public virtual void StateDefault()
    {
        if (entityStateCurrent == EntityStates.Dead)
            SetCurrentState(AIState.Dead);
    }

    public virtual void StateIdle()
    {
        if (entityStateCurrent == EntityStates.Dead)
            return;

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
        if (entityStateCurrent == EntityStates.Dead)
            return;

            if (targetBehaviour.entityStateCurrent != EntityStates.Dead && aiMoveTo.MoveTo(targetObject.transform.position, moveSpeed, targetRangeToAttack))// * 0.6f  
            SetCurrentState(AIState.Attacking);
    }

    public virtual void StateAttacking()
    {
        if (entityStateCurrent == EntityStates.Dead)
            return;

        if (targetBehaviour.entityStateCurrent != EntityStates.Dead)
        {
            if (targetRangeCurrent <= targetRangeToAttack)
                enemyAttack.Attack();
            else
                SetCurrentState(AIState.Following);
        }
        else
            SetCurrentState(AIState.Idle);
    }

    public virtual void StateDead2()
    {
        
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


    /*public void OnDrawGizmos()//visual for minimum attack range
    {
        //Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, minAttackRange);

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, targetRangeToAttack);
    }*/
}

