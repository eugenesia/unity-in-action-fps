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

	// Speed of horizontal rotation wrt mouse movement.
	public float sensitivityHor = 9.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			// vertical rotation here.
		}
		else {
			// both horizontal and vertical rotation here.
		}
	}
}
