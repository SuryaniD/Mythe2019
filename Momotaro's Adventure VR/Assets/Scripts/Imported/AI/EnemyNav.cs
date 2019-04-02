using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyNav : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform goal;

    private float _xOffset = 1.1f;
    private float _dist;

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