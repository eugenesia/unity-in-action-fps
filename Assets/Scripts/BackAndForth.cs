using UnityEngine;
using System.Collections;

// Move an object back and forth along a straight path.
public class BackAndForth : MonoBehaviour {

	public float speed = 3.0f;

	// Positions the object moves between.
	public float maxZ = 16.0f;
	public float minZ = -16.0f;

	// Which direction object is currently moving in.
	private int _direction = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, _direction * speed * Time.deltaTime);

		bool bounced = false;
		if (transform.position.z > maxZ || transform.position.z < minZ) {
			_direction = -_direction;
			bounced = true;
		}

		// Make an extra movement this frame if object switched directions.
		if (bounced) {
			transform.Translate(0, 0, _direction * speed * Time.deltaTime);
		}
	}
}
