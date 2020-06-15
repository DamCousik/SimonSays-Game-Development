
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
	
	}
	
	void FixedUpdate()
	{
		MoveObj ();
	}
	
	void MoveObj() {		
		float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate ( 0f, 0f, moveAmount );	
	}
}























