using UnityEngine;
using System.Collections;

// Controller that spawns the enemy prefab.
public class SceneController : MonoBehaviour {

	// Link to prefab enemy object.
	// Expose the private var in Inspector and store the value, but keep it
	// private and don't allow it to be changed by other scripts.
	[SerializeField] private GameObject enemyPrefab;

	// Keep track of the single enemy instance.
	// Enemy destroys itself when shot, setting _enemy to null.
	private GameObject _enemy;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Only spawn the enemy if there isn't already one.
		if (_enemy == null) {
			// Copy the GameObject. Use "as" to typecast created object.
			_enemy = Instantiate(enemyPrefab) as GameObject;

			// Move enemy to initial position.
			_enemy.transform.position = new Vector3(0, 1, 0);

			// Rotate enemy randomly.
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
		}
	}
}
