using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Buffs/JumpBuff")]
public class JumpBuff: ScriptableBuff
{
	public float jumpIncreases;
	public string name;

	public override TimedBuff InitializeBuff(PlayerController obj)
	{
		return new TimedJumpBuff(Duration, this, obj, name);
	}
}