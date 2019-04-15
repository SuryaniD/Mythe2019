using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class EnemyNav : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    public Transform goal;

    private float _xOffset = 1.1f;
    private float _dist;

    public Action Arrived;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        CheckOffset();
    }
    
    private void Update()
    {
        _dist = Vector3.Distance(agent.transform.position, goal.position);
        CheckDist();
    }

    void CheckDist()
    {
        if (_dist < _xOffset)
        {
            agent.destination = agent.transform.position;
            agent.isStopped = true;
            Arrived?.Invoke();
        }
        else
        {
            CheckTarget();
        }
    }

    void CheckOffset()
    {
        Renderer rend = goal.GetComponent<Renderer>();

        if (rend != null)
        { _xOffset = rend.bounds.size.x * 1.7f; }
    }

    void CheckTarget()
    {
        if (_dist > _xOffset)
        {
            agent.destination = goal.position;
            agent.isStopped = false;
        }
    }


}