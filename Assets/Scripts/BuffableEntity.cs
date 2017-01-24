using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffableEntity: MonoBehaviour {

	public static List<TimedBuff> CurrentBuffs = new List<TimedBuff>();
	private PlayerController player;

	void Start(){
		player = FindObjectOfType<PlayerController> ();
	}

	void Update()
	{
		//if (Game.isPaused)
		//    return;

		foreach(TimedBuff buff in CurrentBuffs.ToArray())
		{
			//Debug.Log ("abc");
			buff.Tick(Time.deltaTime);
			if (buff.IsFinished)
			{
				CurrentBuffs.Remove(buff);
			}
		} 
	}

	public void AddBuff(TimedBuff buff)
	{
		CurrentBuffs.Add(buff);
		buff.Activate();
	}
}