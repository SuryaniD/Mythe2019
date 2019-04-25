using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HitDetection : MonoBehaviour
{
    [SerializeField]
    private float _minimumVelocity;

    [SerializeField]
    private LocationHistory swordloc;

    public GameObject player;

    Animator animator;

    private EntityBehaviour ent;
    public HealthBarScript hbScript;

    private Vector3 diff;

    void Start()
    {
        Getsword();
        animator = GetComponent<Animator>();
        ent = this.GetComponent<EntityBehaviour>();
    }

    void Awake()
    {
        Getsword();
    }

    void Getsword()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //IM SORRY FOR THIS
        swordloc = player.transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<LocationHistory>();
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

        if (
            other.gameObject.tag == "Sword" &&
            CheckDiff() == true
           )
        {
            ent.healthCurrent -= 20;
            hbScript.EnemyHealthChange(ent.healthCurrent);
            animator.Play("Hit");
        }
        
    }
}
