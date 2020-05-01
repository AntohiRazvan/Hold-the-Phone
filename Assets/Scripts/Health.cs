using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    CircleCollider2D collider;
    Animator anim;

    void Awake()
    {
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        } else {
			StartFlicker();
		}
    }

	void StartFlicker()
	{
		StartCoroutine(Flicker());
	}
	IEnumerator Flicker()
 	{	
		float intensity = 0.3f; 
		SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
		Color color = renderer.color;
		float timePassed = 0;
		bool on = true;
		while (timePassed < 0.4f)
		{
			Debug.Log(on);
			if (on) {
				color.a = intensity;
				renderer.color = color;
			} else {
				color.a = 1f;
				renderer.color = color;
			}
			on = !on;
			timePassed += Time.deltaTime;
	
			yield return null;
		}
		color.a = 1f;
		renderer.color = color;

 	}

    void Die()
    {
        Object.Destroy(this.gameObject, 3.0f);
        collider.enabled = false;
        UnityEngine.AI.NavMeshAgent navMeshAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(navMeshAgent)
        {
            navMeshAgent.enabled = false;
        }
        if(anim)
        {
            anim.SetBool("IsDead", true);
        }

    }
}
