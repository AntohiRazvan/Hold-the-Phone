using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Torch : MonoBehaviour
{
    Light2D light;

    void Awake()
    {
        light = gameObject.GetComponent<Light2D>();
    }

    void Update()
    {
        light.intensity = LightManager.lightIntensity;
    }
}
