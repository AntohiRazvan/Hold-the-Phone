using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFires : MonoBehaviour
{
	public float projectileSpeed = 400;
	public float attackSpeed;

	public GameObject projectile;
	Transform firePoint;
	float lastAttack;
	// Start is called before the first frame update
	void Start()
	{
		firePoint = transform.Find("FirePoint") ;
	}

	void Update()
	{
		if(Input.GetButton("Fire1") && Time.time > lastAttack + attackSpeed)
		{
			lastAttack = Time.time;
			GameObject bullet = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.localPosition.normalized * projectileSpeed);
			Destroy(bullet, 5);
		}
	}


}
