//by: Jarno van Lierop
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{ 

    [SerializeField]
    private Image enemyHealthBar;

    [SerializeField]
    private Image playerHealthBar;

    private float startingValue = 100f;
    public Entity entity;
    public EntityBehaviour entityBehaviour;
    private float updatedPlayerHealth;
    private float updatedEnemyHealth;

    private void Start()
    {
        //  entity = GetComponent<Entity>(); // this is wrong it tries to get entity from Healthbar
        PlayerHealthChange(startingValue);
        EnemyHealthChange(startingValue);
        ChangeHealth(startingValue);
    }

    public void ChangeHealth(float _value)
    {
        float amountEnemyHealth = _value;
        enemyHealthBar.fillAmount = amountEnemyHealth / 100;
        Debug.Log(amountEnemyHealth);
    }

    public void PlayerHealthChange(float _value)
    {
        /*if (_value <= 0) {
            entityBehaviour.aiStateCurrent = AIState.Dead;
        } else {
            float amountPlayerHealth = (_value / 100.0f) * 180.0f / 360.0f;
            playerHealthBar.fillAmount = Mathf.Clamp(amountPlayerHealth, 0f, 100f);
        }*/
    }

    public void EnemyHealthChange(float _value)
    {
        float amountEnemyHealth = _value;
        enemyHealthBar.fillAmount = amountEnemyHealth / 100;
        Debug.Log(amountEnemyHealth);
    }
}
