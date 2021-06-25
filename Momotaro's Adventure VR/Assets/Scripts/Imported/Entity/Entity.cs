using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TeamTypes
{
    Noone,
    Friendly,
    Enemy
}

public enum EntityStates
{
    Alive,
    Dying,
    Dead
}

public class Entity : MonoBehaviour
{
    public GameManagerNew gameManagerNew;
    public HealthBarScript hbScript;
    public TeamTypes teamCurrent = TeamTypes.Enemy;
    public EntityStates entityStateCurrent = EntityStates.Alive;
    public Animator anim;
    [SerializeField]
    public float healthCurrent;
    public float startinghealth = 100.0f;
    public float attackDamage = 10.0f;

    private void Awake()
    {
        healthCurrent = startinghealth;
        gameManagerNew = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    { 
        healthCurrent = startinghealth;
    }

    public virtual void TakeDamage()
    {
        if (entityStateCurrent == EntityStates.Dead)
            return;
    }


    //---------------
    //-----State-----
    //---------------

    public void SetCurrentHealthState(EntityStates _value)
    {
        entityStateCurrent = _value;
    }

    public EntityStates CheckHealthState()
    {

        switch (entityStateCurrent)
        {
            case EntityStates.Alive:
                StateAlive();
                break;

            case EntityStates.Dying:
                StateDying();
                break;

            case EntityStates.Dead:
                StateDead();
                break;
        }

        return entityStateCurrent;
    }

    #region State Functions
    public virtual void StateAlive()
    {
        if (healthCurrent <= 0)
        {
            entityStateCurrent = EntityStates.Dying;

            if (entityStateCurrent != EntityStates.Dead)
            {
                entityStateCurrent = EntityStates.Dead;
            }
        }
    }

    public virtual void StateDying()
    {

    }

    public virtual void StateDead()
    {
        EntityDie();
    }
    #endregion



    /// <summary>
    /// Sets the entity to non-active
    /// </summary>
    public void EntityDie()
    {
        print("Entity DIED");

        StartCoroutine(DeathSequence());
    }

    /// <summary>
    /// Sets the entity to non-active
    /// </summary>
    public void EntityDeactivate()
    {

    }

    /// <summary>
    /// Revives the entity
    /// </summary>
    public void EntityRevive(Vector3 _position)
    {

    }

    public virtual IEnumerator DeathSequence()
    {
        anim.Play("Death");

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z), 3f * Time.deltaTime);

        yield return new WaitForSeconds(2f);

        gameManagerNew.Score++;
        gameManagerNew.ScoreUpdated?.Invoke();

        gameObject.SetActive(false);
    }
}