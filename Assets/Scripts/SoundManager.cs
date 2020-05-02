using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource startSound;

    void Start()
    {
        startSound = GetComponent<AudioSource>();
        GameEventManager.GameStarts += OnGameStart;
    }

    void OnGameStart()
    {
		    startSound.Play(0);
    }
}
