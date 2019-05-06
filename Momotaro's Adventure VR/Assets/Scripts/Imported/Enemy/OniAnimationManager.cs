using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniAnimationManager : MonoBehaviour
{
    private Animator animator;

    private Rigidbody rigidBody;

    //Movement variables
    [SerializeField]
    [Range(-1, 1)]
    private float horizontal, vertical;

    [Header("Debug")]
    [SerializeField]
    private bool tryAttack;

    private Vector3 savedPos;


    // Start is called before the first frame update
    void Start()
    {
        savedPos = transform.position;

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (savedPos != transform.position)
            vertical = 1;
        else
            vertical = 0;

        ChangeHorizontal(horizontal);
        ChangeVertical(vertical);

        if (tryAttack)
        {
            tryAttack = false;
            AttackAnimation();
        }
    }

    /// <summary>
    /// Changes the Horizontal movement variable
    /// </summary>
    /// <param name="_value"></param>
    public void ChangeHorizontal(float _value)
    {
        animator.SetFloat("Horizontal", horizontal);
    }

    /// <summary>
    /// Changes the Vertical movement variable
    /// </summary>
    /// <param name="_value"></param>
    public void ChangeVertical(float _value)
    {
        animator.SetFloat("Vertical", vertical);
    }

    /// <summary>
    /// Plays the Attack animation
    /// </summary>
    public void AttackAnimation()
    {
        animator.Play("Attack");
    }


}
