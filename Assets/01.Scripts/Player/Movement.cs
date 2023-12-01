using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
	[SerializeField] private float speed;
	[SerializeField] private float gravity = 1f;

	private CharacterController charController;
	private Vector3 inputDir;
	private float verticalVelocity;

	private void Awake()
	{
		inputReader.OnMovementEvent += MovementHandle;
		charController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		CheckGrounded();
		Vector3 move = inputDir * Time.deltaTime * speed;
		move.y = verticalVelocity;
		charController.Move(move);
	}

	private void CheckGrounded()
	{
		if (charController.isGrounded)
		{
			verticalVelocity = -0.3f;
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}
	}

	private void MovementHandle(Vector2 direction)
	{
		inputDir = Quaternion.Euler(0, -45, 0) * new Vector3(direction.x, 0, direction.y);
	}
}
