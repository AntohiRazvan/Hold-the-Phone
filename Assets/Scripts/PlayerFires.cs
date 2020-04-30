using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFires : MonoBehaviour
{
	public int fireSpeed;
	public GameObject projectile;
	Transform firePoint;
	// Start is called before the first frame update
	void Start()
	{

		firePoint = transform.Find("FirePoint") ;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("Fire1")) {
             GameObject bullet = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
             bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.localPosition.normalized * 600);
		}
	}


}
