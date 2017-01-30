using UnityEngine;
using System.Collections;

public abstract class TimedBuff {

	protected float duration;
	protected ScriptableBuff buff;
	protected PlayerController obj;
	protected string name;
	public bool IsFinished
	{
		get { return duration <= 0? true: false; }
	}

	public TimedBuff(float duration, ScriptableBuff buff, PlayerController obj, string name)
	{
		this.duration = duration;
		this.buff = buff;
		this.obj = obj;
		this.name = name;
	}

	public void Tick(float delta)
	{
		duration -= delta;
		if (duration <= 0) {
			if (name == "InfinityBuff") {
				TimedInfinityBuff.counter--;
			} else if (name == "SpeedBuff") {
				TimedSpeedBuff.counter--;
			} else if (name == "JumpBuff") {
				TimedJumpBuff.counter--;
			} else if (name == "RapidfireBuff") {
				TimedRapidfireBuff.counter--;
			}
			End ();
		}
	}

	public abstract void Activate();
	public abstract void End();
}