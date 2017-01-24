using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Buffs/InfinityBuff")]
public class InfinityBuff: ScriptableBuff
{
	public float speedIncrease;
	public float jumpIncreases;
	public float shotDelayReduces;
	public GameObject infinityBeam;
	public GameObject defaultBeam;
	public string name;

	public override TimedBuff InitializeBuff(PlayerController obj)
	{
		return new TimedInfinityBuff(Duration, this, obj, name);
	}
}
