using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed = 4f;   //Movement Speed of the Player
	public Vector2 movement;           //Movement Axis
	public Rigidbody2D rigidbody;      //Player Rigidbody Component
	public Animator anim;
	public float hf = 0.0f;
	public float vf = 0.0f;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);

	}
	// Update is called once per frame
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		movement = movement.normalized;
		hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
		vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
		if (movement.x < -0.01f) {
			this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
		} else {
			this.gameObject.transform.localScale = new Vector3(1, 1, 1);
		}

		anim.SetFloat("Horizontal", hf);
		anim.SetFloat("Vertical", movement.y);
		anim.SetFloat("Speed", vf);
	}
}
