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
    [SerializeField]
    private float healthCurrent;
    private float startinghealth = 100.0f;
    public float attackDamage = 10.0f;

    private void FixedUpdate()
    {
        //if (healthCurrent <= 0)
        //{
        //    entityStateCurrent = entityStates.Dying;

        //    if (entityStateCurrent != entityStates.Dead)
        //    {
        //        entityStateCurrent = entityStates.Dead;
        //        EntityDie();
        //    }
        //}
    }

    private void Awake()
    {
        gameManagerNew = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerNew>();
    }

    private void Start()
    { 
        healthCurrent = startinghealth;
    }

    public void TakeDamage(TeamTypes type)
    {
        if (type == TeamTypes.Enemy)
        {
            healthCurrent -= attackDamage;
            hbScript.EnemyHealthChange(healthCurrent);
        }

        if (type == TeamTypes.Friendly)
        {
            healthCurrent -= attackDamage;
            hbScript.PlayerHealthChange(healthCurrent);
        }
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
                EntityDie();
            }
        }
    }

    public virtual void StateDying()
    {

    }

    public virtual void StateDead()
    {

    }
    #endregion



    /// <summary>
    /// Sets the entity to non-active
    /// </summary>
    public void EntityDie()
    {
        print("Entity DIED");

        gameManagerNew.Score += 1;
        gameManagerNew.ScoreUpdated?.Invoke();

        gameObject.SetActive(false);
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
}