using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;
    private float enemyDamage;
    private bool targetWithinRange;
    public float minAttackRange = 7.5f;//minimum range for attacking

    [SerializeField]
    private EntityBehaviour attackDelegate;

    void Start()
    {
        anim = GetComponent<Animator>();
        targetWithinRange = false;

        //attackDelegate = GetComponent<EntityBehaviour>();
        //attackDelegate.entityAttack += Attack;
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Attack();
    //    }

    //}

    public void Attack()
    {
        Debug.Log("attack animation");
        anim.Play("Attack1h1");
        DealDamage();
    }
    void DealDamage()
    {
        Debug.Log("damage taken");
    }

    

}
