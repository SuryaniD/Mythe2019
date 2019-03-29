using UnityEngine;
using System;

public class PlayerDies : MonoBehaviour
{
    public Action Death;
    void Start()
    {
        Debug.Log("gonna die");

        if(Death != null)
        Death();  
    }

   
}
