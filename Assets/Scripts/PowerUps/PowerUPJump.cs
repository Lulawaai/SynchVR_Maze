using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PowerUPJump : PowerUps
{
	[SerializeField] private int _jumpHeight;

	private WaitForSeconds _wait2secs = new WaitForSeconds(2.0f);

	public static event Action<int> OnJumpingHigher;

	protected override void PowerUP()
	{
		OnJumpingHigher?.Invoke(_jumpHeight);
		StartCoroutine(ResetRoutine());
	}

	IEnumerator ResetRoutine()
	{
		yield return _wait2secs;
		ResetPowerUP();
	}
}
