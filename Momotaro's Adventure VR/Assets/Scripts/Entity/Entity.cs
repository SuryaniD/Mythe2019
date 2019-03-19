using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Entity : MonoBehaviour
{
    public enum teamTypes
    {
        Noone,
        Friendly,
        Enemy
    }

    public teamTypes teamCurrent = teamTypes.Enemy;

    public float healthCurrent = 100f;//{ get; set; }




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




