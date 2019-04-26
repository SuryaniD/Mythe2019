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
        if (_other.GetComponent<EntityBehaviour>() != null && _other.GetComponent<EntityBehaviour>().teamCurrent == TeamTypes.Friendly)
            _other.GetComponent<EntityBehaviour>().TakeDamage();
    }
}
