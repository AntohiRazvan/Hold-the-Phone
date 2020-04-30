using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float baseSpeed = 4f;
	float movementSpeed;

	Vector2 movementDirection;
	Rigidbody2D rigidbody;
	Transform firePoint;
	Animator anim;


	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponentInChildren<Animator>();
		firePoint = transform.Find("FirePoint") ;
	}

	void FixedUpdate()
	{

		rigidbody.MovePosition(rigidbody.position + movementDirection * movementSpeed * baseSpeed * Time.fixedDeltaTime);

		if(movementDirection.sqrMagnitude - 0.01f >= 0f)
		{
			anim.SetFloat("Horizontal", movementDirection.x);
			anim.SetFloat("Vertical", movementDirection.y);
		}
		anim.SetFloat("Speed", Mathf.Abs(movementSpeed));
	}

	void Update()
	{
		movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		movementSpeed = Mathf.Clamp(movementDirection.sqrMagnitude, 0f, 1f);
		movementDirection.Normalize();
		if (movementDirection.y > 0) {
			firePoint.localPosition  = new Vector3(0f, 0.25f, 0f);
		} else if (movementDirection.y < 0) {
			firePoint.localPosition  = new Vector3(0f, -0.75f, 0f);
		} else if (movementDirection.x != 0) {
			firePoint.localPosition  = new Vector3(0.25f * Mathf.Sign(movementDirection.x), 0f, 0f);
		}
	}
}
