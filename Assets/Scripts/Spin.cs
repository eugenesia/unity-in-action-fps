using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	// Speed of rotation.
	// Public variable's modifications in Inspector are serialized by Unity.
	public float speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate once every frame.
		transform.Rotate(0, speed, 0);
	}
}
