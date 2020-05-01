using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    AudioSource sound;   
    Collider2D collider;
    Animator anim;
	public float timeOfDeath;

    void Awake()
    {
		sound = gameObject.GetComponent<AudioSource>();
        collider = this.gameObject.GetComponent<CircleCollider2D>();
		if (collider == null) {
			collider = this.gameObject.GetComponentInChildren<CapsuleCollider2D>();
		}
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage)
    {
		sound.Play();
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
        Object.Destroy(this.gameObject, timeOfDeath);
        collider.enabled = false;
        UnityEngine.AI.NavMeshAgent navMeshAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(navMeshAgent)
        {
            navMeshAgent.enabled = false;
        }
        if(anim)
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("IsDead", true);
			anim = null;
        }

    }
}
