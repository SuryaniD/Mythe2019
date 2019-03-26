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

    private float updatedPlayerHealth;
    private float updatedEnemyHealth;

    private void Start()
    {
        PlayerHealthChange(updatedPlayerHealth);
        EnemyHealthChange(updatedEnemyHealth);
    }

    private void PlayerHealthChange(float value)
    {
        float amountPlayerHealth = (value / 100.0f) * 180.0f / 360.0f;
        playerHealthBar.fillAmount = amountPlayerHealth;

    }

    private void EnemyHealthChange(float value)
    {
        float amountEnemyHealth = (value);
        enemyHealthBar.fillAmount = amountEnemyHealth;
    }
}
