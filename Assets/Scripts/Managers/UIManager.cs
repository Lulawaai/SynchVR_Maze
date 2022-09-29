using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	private int _score;

	[SerializeField] private Text _scoretxt;
	[SerializeField] private Text _powerUPtxt;
	[SerializeField] private GameObject _keyImage;
	[SerializeField] private GameObject _congrats;

	private void OnEnable()
	{
		PowerUps.OnPowerUPPickUp += UpdatePowerUPtxt;
		PowerUps.OnResetPowerUP += ResetPowerUPtxt;
		PowerUpKey.OnPickingUPKey += HasKey;
		Gems.OnCollectingGem += UPdateScore;
		Door.OnOpenningDoor += DoorOpenned;
	}

	private void Start()
	{
		_scoretxt.text = "Score = 0";
		_powerUPtxt.text = "";
	}

	private void UPdateScore(int points)
	{
		_score += points;
		_scoretxt.text = "Score = " + _score;
	}

	private void UpdatePowerUPtxt(string powerUPName)
	{
		_powerUPtxt.text = powerUPName;
	}

	private void ResetPowerUPtxt()
	{
		_powerUPtxt.text = "";
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}

	private void HasKey()
	{
		_keyImage.SetActive(true);
	}

	private void DoorOpenned()
	{
		_congrats.SetActive(true);
	}

	private void OnDisable()
	{
		PowerUps.OnPowerUPPickUp -= UpdatePowerUPtxt;
		PowerUps.OnResetPowerUP -= ResetPowerUPtxt;
		Gems.OnCollectingGem -= UPdateScore;
		PowerUpKey.OnPickingUPKey -= HasKey;
		Door.OnOpenningDoor -= DoorOpenned;
	}
}
