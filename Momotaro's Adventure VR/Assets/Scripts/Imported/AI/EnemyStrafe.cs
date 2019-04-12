using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafe : MonoBehaviour
{
    void Start()
    {
        EnemyNav nav = GetComponent<EnemyNav>();
        nav.Arrived += DoStrafeCheck;
    }
    
    void DoStrafeCheck()
    { // put strafing logics here
        Debug.Log("delegate went off --strafe");


    }
}
