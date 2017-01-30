using UnityEngine;
using System.Collections;

public class TimedSpeedBuff : TimedBuff
{
	public static int counter = 0;

	private SpeedBuff speedBuff;

	private PlayerController movementComponent;

	public TimedSpeedBuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		speedBuff = (SpeedBuff)buff;
	}

	public override void Activate()
	{
		SpeedBuff speedBuff = (SpeedBuff) buff;
		movementComponent.moveSpeed += speedBuff.speedIncrease;
		movementComponent.speedParticleEffect.SetActive (true);
		counter++;
	}

	public override void End()
	{
		SpeedBuff speedBuff = (SpeedBuff) buff;
		movementComponent.moveSpeed -= speedBuff.speedIncrease;
		if (counter == 0) {
			movementComponent.speedParticleEffect.SetActive (false);
		}
	}
}