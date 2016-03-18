using UnityEngine;
using System.Collections;

// Allow player to look in different directions using the mouse.
public class MouseLook : MonoBehaviour {

	// Show human-readable names for the rotation setting in editor.
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	// Public var to set and serialize in Unity editor.
	public RotationAxes axes = RotationAxes.MouseXAndY;

	// Speed of rotation wrt mouse movement.
	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;

	// Limit vertical rotation for looking up/down.
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	// Vertical angle.
	private float _rotationX = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Allow only horizontal rotation.
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		// Allow only vertical rotation.
		else if (axes == RotationAxes.MouseY) {
			// Set vertical rotation angle directly instead of
			// incrementing/decrementing it via transform.Rotate(). This allows
			// us to restrict the angle range later on.
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

			// Restrict the vertical rotation to min and max angles.
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float rotationY = transform.localEulerAngles.y;

			// Create a new vector and set the rotation angles directly.
			// The reason why we need to create a new Vector3 instead of changing
			// values in the existing vector in the transform is because those
			// values are read-only for transforms.
			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
		// Allow both horizontal and vertical rotation.
		else {
			// Calculate and limit vertical rotation as before.
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			// Calculate the absolute value of horizontal rotation rather than
			// incrementing/decrementing it. This allows us to then set the
			// horizontal and vertical rotation angles directly.
			float delta = Input.GetAxis("Mouse X") * sensitivityHor;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
		}
	}
}
