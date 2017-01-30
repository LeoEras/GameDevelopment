using UnityEngine;
using System.Collections;

public abstract class ScriptableBuff : ScriptableObject
{

	public float Duration;

	public abstract TimedBuff InitializeBuff(PlayerController obj);

}
