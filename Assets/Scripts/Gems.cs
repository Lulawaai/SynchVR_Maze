using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gems : MonoBehaviour
{
	public static event Action<int> OnCollectingGem;
	public static event Action OnCollectingGemSound;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			int i = UnityEngine.Random.Range(1, 5);
			OnCollectingGem?.Invoke(i);
			OnCollectingGemSound?.Invoke();
			Destroy(gameObject);
		}
	}
}
