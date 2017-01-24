using UnityEngine;
using System.Collections;

public class TimedInfinityBuff : TimedBuff
{
	public static int counter = 0;

	private InfinityBuff infinityBuff;

	private PlayerController movementComponent;

	public TimedInfinityBuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		infinityBuff = (InfinityBuff)buff;
	}

	public override void Activate()
	{
		InfinityBuff infinityBuff = (InfinityBuff) buff;
		movementComponent.moveSpeed = infinityBuff.speedIncrease;
		movementComponent.jumpHeight = infinityBuff.jumpIncreases;
		movementComponent.shotDelay = infinityBuff.shotDelayReduces;
		movementComponent.shootingObjet = infinityBuff.infinityBeam;
		movementComponent.fireParticleEffect.SetActive (true);
		counter++;
	}

	public override void End()
	{
		if (counter == 0) {
			movementComponent.moveSpeed = movementComponent.defaultMoveSpeed;
			movementComponent.jumpHeight = movementComponent.defaultJumpHeight;
			movementComponent.shotDelay = movementComponent.defaultShotDelay;
			movementComponent.shootingObjet = movementComponent.defaultBeam;
			movementComponent.fireParticleEffect.SetActive (false);
		}
	}
}