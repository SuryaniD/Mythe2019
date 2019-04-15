using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HitDetection : MonoBehaviour
{
    [SerializeField]
    private float _minimumVelocity;

    [SerializeField]
    private LocationHistory swordloc;

    public int HP = 3;
    Animator animator;

    private Vector3 diff;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private bool CheckDiff()
    {
        if (diff.x >= _minimumVelocity ||
           diff.y >= _minimumVelocity ||
           diff.z >= _minimumVelocity)
        { return true; }
        else { return false; }
    }

    void OnTriggerEnter(Collider other)
    {
        diff = swordloc.locationHistory[0] - swordloc.locationHistory[1];

        if (other.gameObject.tag == "Sword" &&
            CheckDiff() == true
           )
        {
          HP -= 1;
          Debug.Log("hp is now: " + HP);
          if (HP == 0)
          {
              Debug.Log("Death");
              animator.SetTrigger("Fall1");
              Destroy(gameObject, 2.0f);
          }
        }
    }
}
