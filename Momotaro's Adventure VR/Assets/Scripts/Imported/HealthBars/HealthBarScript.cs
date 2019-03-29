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
    private float updatedPlayerHealth;
    private float updatedEnemyHealth;

    private void Start()
    {
        entity = GetComponent<Entity>();
        PlayerHealthChange(startingValue);
        EnemyHealthChange(startingValue);
    }

    public void PlayerHealthChange(float _value)
    {
        float amountPlayerHealth = (_value / 100.0f) * 180.0f / 360.0f;
        playerHealthBar.fillAmount = Mathf.Clamp(amountPlayerHealth, 0f, 100f);
        Debug.Log("player damaged");
    }

    public void EnemyHealthChange(float _value)
    {
        float amountEnemyHealth = _value;
        enemyHealthBar.fillAmount = amountEnemyHealth/100;
    }
}
