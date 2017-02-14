using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Debuffs/PoisonDebuff")]
public class PoisonDebuff: ScriptableBuff
{
	public int healthReduction;
	public string name;

	public override TimedBuff InitializeBuff(PlayerController obj)
	{
		return new TimedPoisonDebuff(Duration, this, obj, name);
	}
}
