using UnityEngine;
using System.Collections;

// Allow moving the player.
public class FPSInput : MonoBehaviour {
	// Speed of movement.
	public float speed = 6.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// "Horizontal" and "Vertical" are indirect names for
		// keyboard mappings.
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;

		// Multiply by deltaTime to get frame rate-independent movement.
		transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
	}
}
