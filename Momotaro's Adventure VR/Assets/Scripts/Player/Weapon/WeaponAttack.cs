using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------
//- This script gives the ability to attack
//- By: Peter Schreuder
//---------------

public class WeaponAttack : MonoBehaviour
{
    private Animator anim;
    private bool canAttack = true;
    [SerializeField]
    private float attackTime = 1f;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetButton("Fire1") && canAttack)
            Attack();
    }


    void Attack()
    {
        canAttack = false;
        StartCoroutine(Alarm_canAttack(attackTime));
        anim.Play("KatanaAttackAnimation");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EntityBehaviour>() != null && other.GetComponent<EntityBehaviour>().teamCurrent == TeamTypes.Enemy)
            other.GetComponent<EntityBehaviour>().TakeDamage(TeamTypes.Enemy);
    }

    IEnumerator Alarm_canAttack(float _value)
    {
        yield return new WaitForSeconds(_value);

        canAttack = true;
    }
}
