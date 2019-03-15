using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Entity : MonoBehaviour
{
    enum teamTypes { Noone, Friendly, Enemy };

    private teamTypes teamCurrent = teamTypes.Noone;

    public float HealthCurrent { get; set; }

    public Entity()
    {
        HealthCurrent = 100f;
        teamCurrent = teamTypes.Noone;
    }





    /// <summary>
    /// Sets the entity on non-active
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




