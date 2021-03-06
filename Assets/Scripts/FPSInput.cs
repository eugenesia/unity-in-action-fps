﻿using UnityEngine;
using System.Collections;


// Ensure that CharacterController component is added.
[RequireComponent(typeof(CharacterController))]
// Add this script to the "Add Component" dropdown.
[AddComponentMenu("Control Script/FPS Input")]


// Allow moving the player.
public class FPSInput : MonoBehaviour {
	// Speed of movement.
	public float speed = 6.0f;

	// Reference CharacterController component.
	private CharacterController _charController;

	public float gravity = -9.8f;

	// Use this for initialization
	void Start () {
		// Access other components connected to the same object.
		_charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// "Horizontal" and "Vertical" are indirect names for
		// keyboard mappings.
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);

		// Limit diagonal movement to same speed as movement along an axis.
		movement = Vector3.ClampMagnitude(movement, speed);
		movement.y = gravity;

		// Make movement speed independent of frame rate.
		movement *= Time.deltaTime;

		// Transform a direction from local space to world space.
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}
}
