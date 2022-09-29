using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PowerUpKey : PowerUps
{
	public static event Action OnPickingUPKey;

	protected override void PowerUP()
	{
		Debug.Log("Picked Up key");
		OnPickingUPKey?.Invoke();
	}
}
