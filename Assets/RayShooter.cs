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
				Debug.Log("Hit " + hit.point);
			}
		}
	}
}
