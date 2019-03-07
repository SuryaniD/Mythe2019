using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionEnemy : MonoBehaviour
{

	public int HP = 3;
	Animator animator;
    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter (Collider other)
	{
		Debug.Log("Bots met"+other.gameObject.tag);
		if(other.gameObject.tag == "Sword")
		{
			HP -= 1;
			if(HP==0) {
				Debug.Log("DOOD");
				animator.SetTrigger("Fall1");
				Destroy(gameObject, 2.0f);
			}
		}
	}
}
