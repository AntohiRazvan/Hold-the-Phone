using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour 
{
	float intensity; 
	Light2D light;

	bool gameOver;

	void Awake () 
	{   
		GameEventManager.TookDamage += StartFlicker;
		GameEventManager.GameOver += GameOver;
		light = GetComponent<Light2D>(); 
		gameOver = false;
	}

	void StartFlicker(float damage)
	{
		StartCoroutine(Flicker());
	}

	IEnumerator Flicker()
 	{	
		if(!gameOver)
		{
			intensity = light.intensity;
			float timePassed = 0;
			while (timePassed < 0.2f)
			{
				light.intensity = intensity + intensity * (Random.Range(-0.8f, 0.3f));
				timePassed += Time.deltaTime;
		
				yield return null;
			}
		}
 	}

	void GameOver(bool hasWon)
	{
		gameOver = true;
	}
}
