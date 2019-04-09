using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum teamTypes
{
    Noone,
    Friendly,
    Enemy
}

public enum entityStates
{
    Alive,
    Dying,
    Dead
}

public class Entity : MonoBehaviour
{

    public HealthBarScript hbScript;
    public teamTypes teamCurrent = teamTypes.Enemy;
    public entityStates entityStateCurrent = entityStates.Alive;
    [SerializeField]
    private float healthCurrent;
    private float startinghealth = 100.0f;
    private float attackDamage = 10.0f;

    private void FixedUpdate()
    {
        if(healthCurrent <= 0)
        {
            entityStateCurrent = entityStates.Dying;

            if (entityStateCurrent != entityStates.Dead)
            {
                entityStateCurrent = entityStates.Dead;
                EntityDie();
            }
        }
    }

    private void Start()
    {
        healthCurrent = startinghealth;
    }

    public void TakeDamage(teamTypes type)
    {
        if (type == teamTypes.Enemy)
        {
            healthCurrent -= attackDamage;
            hbScript.EnemyHealthChange(healthCurrent);
        }

        if (type == teamTypes.Friendly)
        {
            healthCurrent -= attackDamage;
            hbScript.PlayerHealthChange(healthCurrent);
        }
    }

    /// <summary>
    /// Sets the entity to non-active
    /// </summary>
    public void EntityDie()
    {

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