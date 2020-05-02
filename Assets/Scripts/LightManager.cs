using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public static float lightIntensity;
    public float fadeTime;
    public float finalIntensity;
    AudioSource music;
    
    float startingIntensity;
    float elapsedTime;
    System.DateTime startTime;

    void Awake()
    {
        GameEventManager.TookDamage += OnTookDamage;
    }

    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<AudioSource>();
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
            music.volume = Mathf.Lerp( 0.05f, 0.6f, ( elapsedTime / fadeTime ));
            elapsedTime += Time.deltaTime;
        }
        else
        {
            lightIntensity = 0f;
            GameEventManager.TriggerGameOver(false);
        }      
    }

    void OnTookDamage(float damage)
    {
        fadeTime -= damage;
    }

    void OnDestroy()
    {
        GameEventManager.TookDamage -= OnTookDamage;
    }
}
