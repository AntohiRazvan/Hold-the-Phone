using UnityEngine;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameEventOver(bool hasWon);
	public static event GameEventOver GameOver;
    
	public delegate void TookDamageEvent(float damage);
	public static event TookDamageEvent TookDamage;


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
}
