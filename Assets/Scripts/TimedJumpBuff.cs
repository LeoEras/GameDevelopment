using UnityEngine;
using System.Collections;

public class TimedJumpBuff : TimedBuff
{
	public static int counter = 0;

	private JumpBuff jumpBuff;

	private PlayerController movementComponent;

	public TimedJumpBuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		jumpBuff = (JumpBuff)buff;
	}

	public override void Activate()
	{
		JumpBuff jumpBuff = (JumpBuff) buff;
		movementComponent.jumpHeight += jumpBuff.jumpIncreases;
		movementComponent.jumpParticleEffect.SetActive (true);
		counter++;
	}

	public override void End()
	{
		JumpBuff jumpBuff = (JumpBuff) buff;
		movementComponent.jumpHeight -= jumpBuff.jumpIncreases;
		if (counter == 0) {
			movementComponent.jumpParticleEffect.SetActive (false);
		}
	}
}