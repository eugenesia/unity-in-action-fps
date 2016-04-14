using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	// React to being hit. Called by shooting script.
	public void ReactToHit() {
		StartCoroutine(Die());
	}

	// Enemy dying sequence coroutine.
	private IEnumerator Die() {

		// Topple enemy. Rotation is applied instantly.
		this.transform.Rotate(-75, 0, 0);

		// Return control to calling function, to wait for 1.5 seconds.
		yield return new WaitForSeconds(1.5f);

		// Destroy parent gameobject (the enemy). Object can destroy itself
		// just like a separate object.
		Destroy(this.gameObject);
	}
}
