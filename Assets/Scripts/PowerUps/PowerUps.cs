using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class PowerUps : MonoBehaviour
{
	[Header("1-Jump, 2-Axe, 3-Keys")]
	[SerializeField] protected int _powerUPNr;

	[Header("Basics")]
	[SerializeField] protected GameObject _VFX;
	[SerializeField] protected MeshRenderer _rend;
	[SerializeField] protected string _powerNameTxt;
	[SerializeField] protected Collider _collider;

	public static event Action<string> OnPowerUPPickUp;
	public static event Action OnResetPowerUP;
	public static event Action OnPlaySound;

	private void Start()
	{
		_VFX.SetActive(false);
		_rend.enabled = true;
	}

	protected void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PowerUP();
			_VFX.SetActive(true);
			_rend.enabled = false;
			Destroy(gameObject, 3f);
			OnPlaySound?.Invoke();
			OnPowerUPPickUp?.Invoke(_powerNameTxt);
			_collider.enabled = false;
		}
	}

	protected virtual void PowerUP()
	{

	}

	protected void ResetPowerUP()
	{
		OnResetPowerUP?.Invoke();
	}
}
