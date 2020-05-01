using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	float baseSpeed = 4f;
	float movementSpeed;

	AudioSource audioData;
	Vector2 movementDirection;
	Rigidbody2D rigidbody;
	Transform firePoint;
	Animator anim;
	LightFollow lightFollow;


	void Awake()
	{
		rigidbody = this.GetComponent<Rigidbody2D>();
		anim = this.GetComponentInChildren<Animator>();
		lightFollow = this.GetComponentInChildren<LightFollow>();
		firePoint = transform.Find("FirePoint") ;
		audioData = GetComponent<AudioSource>();
		audioData.Play(0);
		audioData.Pause();
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
			audioData.UnPause();
			firePoint.localPosition  = new Vector3(0f, 0.55f, 0f);
			lightFollow.followPlayer(0f);
		} else if (movementDirection.y < 0) {
			audioData.UnPause();
			firePoint.localPosition  = new Vector3(0f, -0.75f, 0f);
			lightFollow.followPlayer(180f);
		} else if (movementDirection.x != 0) {
			firePoint.localPosition  = new Vector3(0.45f * Mathf.Sign(movementDirection.x), 0f, 0f);
			lightFollow.followPlayer(-90f * Mathf.Sign(movementDirection.x));
			audioData.UnPause();
		} else {
			audioData.Pause();
		}
	}



}
