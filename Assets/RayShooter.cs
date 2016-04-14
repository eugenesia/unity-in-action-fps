using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	// Use this for initialization
	void Start () {
		// Access the camera component attached to same object.
		_camera = GetComponent<Camera>();

		// Hide mouse cursor at centre of screen so as not to interfere with crosshair.
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Called in the GUI drawing phase, after 3D rendering.
	// Draw a crosshair in the centre of the screen.
	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;

		// Display text on screen to act as crosshair.
		GUI.Label(new Rect(posX, posY, size, size), "*");
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

				// The GameObject that was hit.
				GameObject hitObject = hit.transform.gameObject;

				// ReactiveTarget script component on the object.
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

				if (target != null) {
					// GameObject with ReactiveTarget component was hit.
					Debug.Log("Target hit");
				} else {
					// Something else was hit.
					// Launch non-blocking coroutine to show a sphere where ray hit something.
					StartCoroutine(SphereIndicator(hit.point));
				}
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
