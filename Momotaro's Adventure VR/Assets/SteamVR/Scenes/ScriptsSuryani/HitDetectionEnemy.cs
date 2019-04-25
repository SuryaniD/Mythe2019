using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionEnemy : MonoBehaviour
{
    private EntityBehaviour ent;
    public HealthBarScript hbScript;
	
	Animator animator;
    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
        ent = this.GetComponent<EntityBehaviour>();
    }

    

	void OnTriggerEnter (Collider other)
	{
		//Debug.Log("Bots met"+other.gameObject.tag);
		if(other.gameObject.tag == "Sword")
		{
            ent.healthCurrent -= 50;
            hbScript.EnemyHealthChange(ent.healthCurrent);
            animator.Play("Hit");
        }
	}
}
