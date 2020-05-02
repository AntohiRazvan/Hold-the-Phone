using UnityEngine;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameEventOver(bool hasWon);
	public static event GameEventOver GameOver;
    
	public delegate void TookDamageEvent(float damage);
	public static event TookDamageEvent TookDamage;

	public delegate void GameStartsEvent();
	public static event GameStartsEvent GameStarts;

    public static void TriggerTookDamage(float damage)
	{
		if (TookDamage != null)
		{
			TookDamage(damage);
		}
	}

	public static void TriggerGameOver(bool hasWon)
	{
		if (GameOver != null)
		{
			GameOver(hasWon);
		}
	}
	public static void TriggerGameStart()
	{
			Debug.Log("bla null");
		if (GameStarts != null) 
		{
			Debug.Log("Not null");
			GameStarts();
		}
	}

	public static void OnDestroy()
	{
		GameOver = null;
		TookDamage = null;
		GameStarts = null;
	}
}
