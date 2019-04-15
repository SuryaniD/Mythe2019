using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(EnemyNav))]
public class EnemyStrafe : MonoBehaviour
{
    EnemyNav _nav;

    void Start()
    {
        _nav = GetComponent<EnemyNav>();
        _nav.Arrived += DoStrafeCheck;
    }
    
    void DoStrafeCheck()
    { // put strafing logics here
        Debug.Log("delegate went off --strafe");

    }
}
