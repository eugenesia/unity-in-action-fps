using UnityEngine;
using System.Collections;

// This is attached to a GameObject so other scripts can recognize this object
// as the player.
public class PlayerCharacter : MonoBehaviour {
	private int _health;

	// Use this for initialization
	void Start () {
		_health = 5;
	}

	// Allow other scripts to hurt the player.
	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);
	}

	// Update is called once per frame
	void Update () {
	}
}
