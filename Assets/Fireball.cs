using UnityEngine;
using System.Collections;

// Fireball shooting behavior.
public class Fireball : MonoBehaviour {

	// How fast the fireball moves.
	public float speed = 10.0f;
	// How much damage it causes the player.
	public int damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Move forward.
		transform.Translate(0, 0, speed * Time.deltaTime);
	}

	// Called when fireball collides, e.g. with walls or player.
	// For this to be called, one of the objects must have a RigidBody
	// component.
	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}
}
