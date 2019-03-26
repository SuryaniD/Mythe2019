using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    public enum teamTypes
    {
        Noone,
        Friendly,
        Enemy
    }
    public Action<float> DamageTaken;

    public teamTypes teamCurrent = teamTypes.Enemy;

    public float healthCurrent = 100f;//{ get; set; }

    public void TakeDamage(float _value)
    {
        healthCurrent -= _value;

        if (DamageTaken != null)
        {
            DamageTaken(healthCurrent);
        }
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




