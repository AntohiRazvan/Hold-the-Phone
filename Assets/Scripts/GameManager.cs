using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameOverText;

    void Start()
    {
        GameEventManager.GameOver += GameOver;
    }

    void GameOver()
    {
        //Time.timeScale = 0;
        StartCoroutine(FadeInText(2.5f));
        StartCoroutine(RestartGameAfter(5f));
    }

    IEnumerator RestartGameAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    IEnumerator FadeInText(float seconds)
    {
        Color newColor = gameOverText.color;
        newColor.a = 1f;
        float t = 0f;

        while( t < 1)
        {
            gameOverText.color = Color.Lerp(gameOverText.color, newColor, t);
            Debug.Log(gameOverText.color.a);
            t += Time.deltaTime/seconds;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
