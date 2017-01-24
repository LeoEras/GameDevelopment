using UnityEngine;
using System.Collections;

public abstract class ScriptableBuff : ScriptableObject
{

	public float Duration;
	public string name;

	public abstract TimedBuff InitializeBuff(PlayerController obj);

}
