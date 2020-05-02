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

	enum GameState 
	{
		Stop,
		Starting,
		Running
	}
	GameState state;
    void Awake()
    {
        GameEventManager.TookDamage += OnTookDamage;
        GameEventManager.GameStarts += OnGameStart;
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<AudioSource>();
        startTime = System.DateTime.UtcNow;
        lightIntensity = 0f;
        startingIntensity = 1f;
        elapsedTime = 0;
    }

    void Update()
    {
		if (state== GameState.Stop) {
			return;
		}
		if (state == GameState.Starting) {
			FadeInLight();
			return;
		}

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

	void OnGameStart() {
		state = GameState.Starting;
		Debug.Log("lightGameStarting");
	}

	float yVelocity = 0.0f;
	void FadeInLight() {
		lightIntensity = Mathf.SmoothDamp( lightIntensity, 1f, ref yVelocity, 0.9f);
		elapsedTime += Time.deltaTime;
		if (Mathf.Approximately(lightIntensity, 1f)) {
			state = GameState.Running;
			elapsedTime = 0;
		}
	}
}
