using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;
    private float enemyDamage;
    private bool targetWithinRange;
    public float minAttackRange = 7.5f;//minimum range for attacking

    public string aniAttack = "Attack";

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
        anim.Play(aniAttack);
        DealDamage();
    }

    void DealDamage()
    {
        
    }

    

}
