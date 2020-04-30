using UnityEngine;
using System.Collections;

public class GameEventManager 
{
	public delegate void GameEvent();
    public delegate void TookDamageEvent(float damage);
	public static event GameEvent GameOver;
    public static event TookDamageEvent TookDamage;


    public static void TriggerTookDamage(float damage)
	{
		if (TookDamage != null)
		{
			TookDamage(damage);
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
