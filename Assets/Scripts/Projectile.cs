
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	void Awake()
	{
		AudioSource audioData = GetComponent<AudioSource>();
		audioData.Play(0);

	}
	void OnCollisionEnter2D(Collision2D collision)
    {
		Object.Destroy(this.gameObject);
	}

}
