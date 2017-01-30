using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Buffs/RapidfireBuff")]
public class RapidfireBuff: ScriptableBuff
{
	public int shotDelayReductionFactor;
	public string name;

	public override TimedBuff InitializeBuff(PlayerController obj)
	{
		return new TimedRapidfireBuff(Duration, this, obj, name);
	}
}
