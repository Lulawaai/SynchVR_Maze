using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
	private GameInputActions _input;
	private Vector2 _move;

	public static event Action<Vector2> OnMoving;
	public static event Action OnJumping;

	private void Awake()
	{
		_input = new GameInputActions();
	}

	private void OnEnable()
	{
		_input.Enable();
	}
	private void Start()
	{
		_input.Player.Jump.performed += Jump_performed;
	}

	private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		OnJumping?.Invoke();
	}

	private void Update()
	{
		_move = _input.Player.Move.ReadValue<Vector2>();
		OnMoving?.Invoke(_move);
	}

	private void OnDisable()
	{
		_input.Disable();
	}
}
