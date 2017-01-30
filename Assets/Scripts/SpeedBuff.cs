using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Buffs/SpeedBuff")]
public class SpeedBuff: ScriptableBuff
{
	public float speedIncrease;
	public string name;

	public override TimedBuff InitializeBuff(PlayerController obj)
	{
		return new TimedSpeedBuff(Duration, this, obj, name);
	}
}
