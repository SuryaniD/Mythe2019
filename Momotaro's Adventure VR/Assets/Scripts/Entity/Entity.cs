using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        enum teamTypes { Noone, Friendly, Enemy };
    
        public float HealthCurrent { get; set; }

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
}


