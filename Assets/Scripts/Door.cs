using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
	private bool _hasKey;

	[Header("Colliders")]
	[SerializeField] private MeshCollider _meshCollider;
	[SerializeField] private MeshRenderer _doorRight;
	[SerializeField] private MeshRenderer _doorLeft;

	public static event Action OnOpenningDoor;

	private void OnEnable()
	{
		PowerUpKey.OnPickingUPKey += KeyCollection;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && _hasKey)
		{
			StartCoroutine(DoorCloseRoutine());
		}
	}

	IEnumerator DoorCloseRoutine()
	{
		yield return new WaitForSeconds(0.5f);
		_doorLeft.enabled = true;
		_doorRight.enabled = true;
		_meshCollider.enabled = true;

		OnOpenningDoor?.Invoke();
	}

	private void KeyCollection()
	{
		_hasKey = true;
	}

	private void OnDisable()
	{
		PowerUpKey.OnPickingUPKey -= KeyCollection;
	}
}
