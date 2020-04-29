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
	public Animator anim;


	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponentInChildren<Animator>();
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
	}
}
