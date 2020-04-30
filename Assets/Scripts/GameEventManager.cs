using UnityEngine;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameEvent();
	public static event GameEvent TookDamage, GameOver;


    public static void TriggerTookDamage()
	{
		if (TookDamage != null)
		{
			TookDamage();
		}
	}

	public static void TriggerGameOver()
	{
		if (GameOver != null)
		{
			GameOver();
		}
	}
}