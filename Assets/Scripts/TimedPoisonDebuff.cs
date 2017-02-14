using UnityEngine;
using System.Collections;

public class TimedPoisonDebuff : TimedBuff
{
	public static int counter = 0;

	private PoisonDebuff poisonDebuff;

	private PlayerController movementComponent;

	private int healthReduction;

	public TimedPoisonDebuff(float duration, ScriptableBuff buff, PlayerController obj, string name) : base(duration, buff, obj, name)
	{
		movementComponent = obj.GetComponent<PlayerController> ();
		poisonDebuff = (PoisonDebuff)buff;
	}

	public override void Activate()
	{
		movementComponent.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 0f);
		counter++;
	}

	public override void End()
	{
		if (counter == 0) {
			movementComponent.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
		}
	}
}