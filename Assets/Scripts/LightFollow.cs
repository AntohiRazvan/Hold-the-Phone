
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
	bool runningRotate = false;
	float targetAngle = 0;

	public void followPlayer(float angle) {
		targetAngle = angle;
	}

	// State for SmoothDampAngle
	float velocityAngle = 0.0f;
	Vector3 velocityPosition = new Vector3(0f,0f,0f);
	void Update()
	{
		float smooth =0.1f;
		Vector3 currentAngle = transform.localEulerAngles;
		currentAngle.z = Mathf.SmoothDampAngle(transform.localEulerAngles.z, targetAngle,ref velocityAngle, smooth);
		transform.localEulerAngles = currentAngle;

		transform.localPosition = Vector3.SmoothDamp(transform.localPosition,
						getLightPositionForAngle(targetAngle),
						ref velocityPosition,
						smooth);


	}

	public Vector3 up = new Vector3(-0.021f, -0.386f, 2f);
	public Vector3 down = new Vector3(0.002f, 0.555f, 2f);
	public Vector3 left = new Vector3(0.356f, -0.046f, 2f);
	public Vector3 right = new Vector3(-0.356f, 0.046f, 2f);
	Vector2 getLightPositionForAngle(float angle) {
		switch(angle) {
			case 0:
				return up;
			case 180:
				return down;
			case 90:
				return left;
			case -90:
				return right;
			default:
				return up;
		}
	}

	/* IEnumerator RotateLight() */
	/* { */
	/*	running = true; */
	/*	Vector3 target = new Vector3(0,0,0); */
	/*	Debug.Log(Mathf.Abs(target.z-transform.localEulerAngles.z)); */
	/*	while (Mathf.Abs(targetAngle - transform.localEulerAngles.z) > 1 &&  ) */
	/*	{ */
	/*		target.z = Mathf.SmoothDampAngle(transform.localEulerAngles.z, targetAngle,ref yVelocity, smooth); */
	/*		transform.localEulerAngles = target; */
	/*		yield return null; */
	/*	} */
	/*	running = false; */
	/* } */

}
