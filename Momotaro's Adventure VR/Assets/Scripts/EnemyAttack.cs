using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();        
    }

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }
    }

    void attack()
    {
        Debug.Log("attack animation");
        anim.Play("Attack1h1");
        takeDamage();
    }
    void takeDamage()
    {
        Debug.Log("damage taken");
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.//target name)
    //    {
    //        takeDamage();
    //    }
    //}

  
}
