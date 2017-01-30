using UnityEngine;
using System.Collections;

public class TimedRapidfireBuff : TimedBuff
{
	public static int counter = 0;

	private RapidfireBuff rapidfireBuff;

	private PlayerController movementComponent;

	private float shotDelayReduction;

	public TimedRapidfireBuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		rapidfireBuff = (RapidfireBuff)buff;
	}

	public override void Activate()
	{
		RapidfireBuff rapidfireBuff = (RapidfireBuff) buff;
		shotDelayReduction = movementComponent.shotDelay / rapidfireBuff.shotDelayReductionFactor;
		movementComponent.shotDelay -= shotDelayReduction;
		movementComponent.rapidfireParticleEffect.SetActive (true);
		counter++;
	}

	public override void End()
	{
		RapidfireBuff rapidfireBuff = (RapidfireBuff) buff;
		movementComponent.shotDelay += shotDelayReduction;
		if (counter == 0) {
			movementComponent.rapidfireParticleEffect.SetActive (false);
		}
	}
}