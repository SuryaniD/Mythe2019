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

        print("Attack");
        anim.Play("KatanaAttackAnimation");


    }

    IEnumerator Alarm_canAttack(float _value)
    {
        yield return new WaitForSeconds(_value);

        canAttack = true;
    }
}
