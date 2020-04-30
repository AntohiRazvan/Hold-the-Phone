using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour 
{
	float intensity; 
	Light2D light;

	void Awake () 
	{   
		GameEventManager.TookDamage += StartFlicker;
		light = GetComponent<Light2D>(); 
	}

	void StartFlicker(float damage)
	{
		StartCoroutine(Flicker());
	}

	IEnumerator Flicker()
 	{	
		intensity = light.intensity;
		float timePassed = 0;
		while (timePassed < 0.2f)
		{
			light.intensity = intensity + intensity * (Random.Range(-0.5f, 0.2f));
			timePassed += Time.deltaTime;
	
			yield return null;
		}
 	}
}
