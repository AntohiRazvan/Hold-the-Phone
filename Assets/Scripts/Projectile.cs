
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float damage;
	void Awake()
	{
		AudioSource audioData = GetComponent<AudioSource>();
		audioData.Play(0);

	}

	void OnCollisionEnter2D(Collision2D collider)
    {
		Object.Destroy(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider)
    {
		if(collider.gameObject.tag == "Enemy")
		{
			Object.Destroy(this.gameObject);
			collider.gameObject.GetComponent<Health>().TakeDamage(damage);
		}
	}
}
