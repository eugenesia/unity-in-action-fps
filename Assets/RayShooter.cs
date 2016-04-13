using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	// Use this for initialization
	void Start () {
		// Access the camera component attached to same object.
		_camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		// Respond to mouse click.
		if (Input.GetMouseButtonDown(0)) {
			// Middle of screen is half its width and height.
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);

			// Create a ray from camera to screen point.
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				// Launch non-blocking coroutine to show a sphere where ray hit something.
				StartCoroutine(SphereIndicator(hit.point));
			}
		}
	}

	// Create a sphere to indicate where the ray hit.
	// Coroutines use IEnumerator functions.
	// pos: Position to create a sphere.
	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

		// Set centre of sphere.
		sphere.transform.position = pos;

		// Yield keyword tells coroutines where to pause.
		yield return new WaitForSeconds(1);

		// After the pause, remove this GameObject and clear its memory.
		Destroy(sphere);
	}
}
