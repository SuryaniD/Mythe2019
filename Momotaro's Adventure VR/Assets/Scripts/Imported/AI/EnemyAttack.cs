using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Entity entity;
    private Animator anim;
    private float enemyDamage;
    private bool targetWithinRange;
    public float minAttackRange = 7.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        targetWithinRange = false;
    }

    public void Attack()
    {
        anim.Play("Attack1h1");
        DealDamage();
    }
    void DealDamage()
    {
        entity.TakeDamage(teamTypes.Friendly);
    }

    

}
