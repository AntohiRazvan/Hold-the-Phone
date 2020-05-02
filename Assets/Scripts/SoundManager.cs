using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource startSound;

    void Start()
    {
		Debug.Log("SoundSStart");
        startSound = GetComponent<AudioSource>();
        GameEventManager.GameStarts += OnGameStart;
    }

    void OnGameStart()
    {
		Debug.Log("OnGameStart");
		startSound.Play(0);
    }
}
