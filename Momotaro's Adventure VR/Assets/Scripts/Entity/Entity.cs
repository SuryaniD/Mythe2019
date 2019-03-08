using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        enum teamTypes { Noone, Friendly, Enemy };

        private float healthCurrent;
        public float HealthCurrent
        {
            get { return healthCurrent; }
            set { healthCurrent = value; }
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
}


