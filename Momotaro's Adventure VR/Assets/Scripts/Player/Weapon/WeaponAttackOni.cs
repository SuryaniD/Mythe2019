using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------
//- This script gives the ability to attack
//- By: Peter Schreuder
//---------------

public class WeaponAttackOni : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        print("HIT PLAYER");
        if (_other.GetComponent<Entity>() != null && _other.GetComponent<Entity>().teamCurrent == TeamTypes.Friendly)
            _other.GetComponent<Entity>().TakeDamage();
    }
}
