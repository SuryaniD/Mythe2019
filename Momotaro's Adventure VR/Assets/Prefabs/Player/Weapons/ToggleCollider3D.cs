using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------
//- This script is meant to be used with animation events
//- By: Peter Schreuder
//---------------

public class ToggleCollider3D : MonoBehaviour
{
    [SerializeField]
    private bool startActive = false;

    [SerializeField]
    private Collider mainCollider;

    void Start()
    {
        mainCollider = GetComponent<Collider>();

        //Check if the game starts with the collider activated
        mainCollider.enabled = startActive ? true : false;
    }

    /// <summary>
    /// Activates the collider
    /// </summary>
    public void ActivateCollider()
    {
        mainCollider.enabled = true;
    }

    /// <summary>
    /// Deactivates the collider
    /// </summary>
    public void DeactivateCollider()
    {
        mainCollider.enabled = false;
    }
}
