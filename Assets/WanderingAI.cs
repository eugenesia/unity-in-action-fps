﻿using UnityEngine;
using System.Collections;

// For enemies to wander around and avoid obstacles.
public class WanderingAI : MonoBehaviour {

	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Move forward continuously every frame, regardless of turning.
		transform.Translate(0, 0, speed * Time.deltaTime);

		// Ray at the same position and pointing the same direction as character.
		Ray ray = new Ray(transform.position, transform.forward);

		RaycastHit hit;

		// Do raycasting with a circumference around the ray.
		// Use spherecast instead of raycase to account for width of enemy.
		// Set cast sphere radius at 0.75.
		if (Physics.SphereCast(ray, 0.75f, out hit)) {

			// Obstacle is within range.
			if (hit.distance < obstacleRange) {

				// Turn a random angle away from forward.
				float angle = Random.Range(-110, 110);
				transform.Rotate(0, angle, 0);
			}
		}
	}
}