using UnityEngine;
using System.Collections;

public class TimedInfinityBuff : TimedBuff
{
	public static int counter = 0;

	private InfinityBuff infinityBuff;

	private PlayerController movementComponent;

	private float shotDelayReduction;

	public TimedInfinityBuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		infinityBuff = (InfinityBuff)buff;
	}

	public override void Activate()
	{
		InfinityBuff infinityBuff = (InfinityBuff) buff;
		movementComponent.moveSpeed += infinityBuff.speedIncrease;
		movementComponent.jumpHeight += infinityBuff.jumpIncreases;
		shotDelayReduction = movementComponent.shotDelay / infinityBuff.shotDelayReductionFactor;
		movementComponent.shotDelay -= shotDelayReduction;
		movementComponent.shootingObjet = infinityBuff.infinityBeam;
		movementComponent.fireParticleEffect.SetActive (true);
		counter++;
	}

	public override void End()
	{
		InfinityBuff infinityBuff = (InfinityBuff) buff;
		movementComponent.moveSpeed -= infinityBuff.speedIncrease;
		movementComponent.jumpHeight -= infinityBuff.jumpIncreases;
		movementComponent.shotDelay += shotDelayReduction;
		if (counter == 0) {
			movementComponent.shootingObjet = movementComponent.defaultBeam;
			movementComponent.fireParticleEffect.SetActive (false);
		}
	}
}