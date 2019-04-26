using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityEnemy : EntityBehaviour
{
    public override void TakeDamage()
    {
        if (entityStateCurrent == EntityStates.Dead)
            return;

        healthCurrent -= attackDamage;
        hbScript.EnemyHealthChange(healthCurrent);
        anim.enabled = false;
        anim.enabled = true;
        anim.Play("Hit");
    }

    public override IEnumerator DeathSequence()
    {
        anim.Play("Death");

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z), 3f * Time.deltaTime);

        yield return new WaitForSeconds(2f);

        gameManagerNew.Score++;
        gameManagerNew.ScoreUpdated?.Invoke();

        gameObject.SetActive(false);
    }
}
