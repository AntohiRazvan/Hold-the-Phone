using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static float lightIntensity;
    public float fadeTime;
    public float finalIntensity;
    
    float startingIntensity;
    float elapsedTime;
    System.DateTime startTime;

    void Awake()
    {
        GameEventManager.TookDamage += OnTookDamage;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        startTime = System.DateTime.UtcNow;
        lightIntensity = 1f;
        startingIntensity = lightIntensity;
        elapsedTime = 0;
    }

    void Update()
    {
        if( elapsedTime <= fadeTime )
        {
            lightIntensity = Mathf.Lerp( startingIntensity, finalIntensity, ( elapsedTime / fadeTime ));
            elapsedTime += Time.deltaTime;
        }
        else
        {
            lightIntensity = 0f;
            GameEventManager.TriggerGameOver();
        }      
    }

    void OnTookDamage(float damage)
    {
        fadeTime -= damage;
    }
}
