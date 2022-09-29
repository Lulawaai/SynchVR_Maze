using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	[Header("Player Basics")]
	[SerializeField] private float _speed;
	[SerializeField] private float _rotSpeed;
	[SerializeField] private float _originalJumpHeight;
	[SerializeField] private bool _isPlayerGrounded;
	[SerializeField] private float _jumpHeight;

	[SerializeField] private Rigidbody _rb;
	[SerializeField] private CharacterController _controller;

	private Vector3 _direction;
	private WaitForSeconds _wait3Sec = new WaitForSeconds(3.0f);

	public static event Action OnPlayingFootSteps;
	public static event Action OnStopingFootSteps;
	public static event Action OnPlayingJumpingSound;

	private void OnEnable()
	{
		InputManager.OnMoving += Move;
		InputManager.OnJumping += Jump;

		PowerUPJump.OnJumpingHigher += PowerUpJump;
	}

	private void Start()
	{
		_jumpHeight = _originalJumpHeight;
	}

	private void FixedUpdate()
	{
		int layerMask = 1 << 8;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1, layerMask))
		{
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
			//Debug.Log("did hit" + hit.ToString());
			_isPlayerGrounded = true;
		}
		else
			_isPlayerGrounded = false;

	}

	private void Update()
	{
		PlayerMove();

		if (_direction.y != 0)
		{
			OnPlayingFootSteps?.Invoke();
		}
		else
		{
			OnStopingFootSteps?.Invoke();
		}
	}

	private void PlayerMove()
	{
		transform.Rotate(0, _direction.x * _rotSpeed, 0);

		Vector3 move = transform.TransformDirection(Vector3.forward);
		float curSpeed = _speed * _direction.y;
		_controller.SimpleMove(move * curSpeed);
	}

	private void Move(Vector2 move)
	{
		_direction = move;
	}

	private void Jump()
	{
		if (_isPlayerGrounded)
		{
			_direction.y += _jumpHeight;

			OnPlayingJumpingSound?.Invoke();
		}
		_controller.Move(_direction * Time.deltaTime);

	}

	#region PowerUPs
	private void PowerUpJump(int jumpHeight)
	{
		_jumpHeight = jumpHeight;
		StartCoroutine(JumpPowerUpFinished());
	}

	IEnumerator JumpPowerUpFinished()
	{
		yield return _wait3Sec;
		_jumpHeight = _originalJumpHeight;
	}
	#endregion

	private void OnDisable()
	{
		InputManager.OnMoving -= Move;
		InputManager.OnJumping -= Jump;

		PowerUPJump.OnJumpingHigher -= PowerUpJump;
	}
}
