using UnityEngine;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameOverEvent(bool hasWon);
	public static event GameOverEvent GameOver;
    
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
		if (GameStarts != null) 
		{
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
