using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private const float Y_ANGLE_MIN = 10.0f;
	private const float Y_ANGLE_MAX = 50.0f;

	public Transform lookAt;
	public Transform camTransform;
	public bool Ground = false;
	public bool Flying = false;

	private Camera cam;

	private float distance = 5.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensitivityX = 4.0f;
	private float sensitivityY = 1.0f;

	private void Start(){
		camTransform = transform;
		cam = Camera.main;
	}

	private void Update(){
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
	}

	private void LateUpdate(){
		Normal ();
		InFlight ();
	}

	private void Normal(){
		if(Ground == true){
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
		}
	}
	private void InFlight(){
		if (Flying == true) {
			Vector3 dir = new Vector3 (0, 0, -15);
			Quaternion rotation = Quaternion.Euler (currentY, currentX, 0);
			camTransform.position = lookAt.position + rotation * dir;
			camTransform.LookAt (lookAt.position);
		}
	}
}
