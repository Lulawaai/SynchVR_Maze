using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioSource _backgroundAS;
	[SerializeField] private AudioSource _gemAS;
	[SerializeField] private AudioSource _powerUP;
	[SerializeField] private AudioSource _jumpAS;
	[SerializeField] private AudioSource _runningAS;

	private void OnEnable()
	{
		Gems.OnCollectingGemSound += PlayGemCollectionSound;
		PowerUps.OnPlaySound += PlayPowerUpSound;
		Player.OnPlayingFootSteps += PlayFootSteps;
		Player.OnStopingFootSteps += StopFootSteps;
		Player.OnPlayingJumpingSound += PlayJumpSound;
	}

	private void PlayGemCollectionSound()
	{
		_gemAS.Play();
	}

	private void PlayPowerUpSound()
	{
		_powerUP.Play();
	}

	private void PlayFootSteps()
	{
		if (!_runningAS.isPlaying)
		{
			_runningAS.Play();
		}
	}

	private void StopFootSteps()
	{
		_runningAS.Stop();
	}

	private void PlayJumpSound()
	{
		_jumpAS.Play();
	}

	private void OnDisable()
	{
		Gems.OnCollectingGemSound -= PlayGemCollectionSound;
		PowerUps.OnPlaySound -= PlayPowerUpSound;
		Player.OnPlayingFootSteps -= PlayFootSteps;
		Player.OnStopingFootSteps -= StopFootSteps;
		Player.OnPlayingJumpingSound -= PlayJumpSound;
	}
}
