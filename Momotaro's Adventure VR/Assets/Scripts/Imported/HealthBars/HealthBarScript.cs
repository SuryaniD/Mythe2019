using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    private float startingHealth = 100f;

    [SerializeField]
    private Image enemyHealthBar;
    [SerializeField]
    private Image playerHealthBar;

    

    private float updatedPlayerHealth;
    private float updatedEnemyHealth;

    private void Start()
    {
        PlayerHealthChange(startingHealth);
        EnemyHealthChange(updatedEnemyHealth);
    }

    private void PlayerHealthChange(float value)
    {
        float amountPlayerHealth = (value / 100.0f) * 180.0f / 360.0f;
        playerHealthBar.fillAmount = Mathf.Clamp(amountPlayerHealth, 0f, 100f);

    }

    private void EnemyHealthChange(float value)
    {
        float amountEnemyHealth = (value);
        enemyHealthBar.fillAmount = Mathf.Clamp(amountEnemyHealth, 0f, 100f);
    }
}
