using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Torch : MonoBehaviour
{
    [SerializeField]
    float fadeTime = 300;
    [SerializeField]
    float finalIntensity = 0.1f;
    
    System.DateTime startTime;
    Light2D light;
    float startingIntensity;

    void Awake()
    {
        startTime = System.DateTime.UtcNow;
        light = gameObject.GetComponent<Light2D>();
        startingIntensity = light.intensity;

        StartCoroutine( FadeOverSeconds() );
    }

    public IEnumerator FadeOverSeconds()
    {
        float elapsedTime = 0;
        while ( elapsedTime < fadeTime )
        {
            light.intensity = Mathf.Lerp( startingIntensity, finalIntensity, ( elapsedTime / fadeTime ));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        light.intensity = finalIntensity;
 }
}
