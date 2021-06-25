using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPlayer : Entity
{

    public override void TakeDamage()
    {
        if (entityStateCurrent == EntityStates.Dead)
            return;

        healthCurrent -= attackDamage;
        hbScript.PlayerHealthChange(healthCurrent);

        DamageIndicator _dmgI = GetComponent<DamageIndicator>();
        _dmgI.Hit();
    }

    void FixedUpdate()
    {
        CheckHealthState();
    }

    public override IEnumerator DeathSequence()
    {
        
        yield return new WaitForSeconds(2f);
        
    }
}
