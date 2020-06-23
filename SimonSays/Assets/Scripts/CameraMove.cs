
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed = -7.0f;
    private string system;
    public GameObject mainCamera;
	GameObject character;
	private int waitTime;

	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
		character = GameObject.Find("MaleFreeSimpleMovement1");

		#if UNITY_EDITOR
			moveSpeed = -6.0f;
		#endif
	}

	void FixedUpdate()
    {
		CharacterMovement tryM = character.GetComponent<CharacterMovement>();
	    if (!tryM.chrctrIsDead && tryM.characterIsMoving)
		{ 
		    MoveObj();
	    }
        
    }

    void MoveObj()
    {
        float moveAmount = Time.smoothDeltaTime * moveSpeed;
        transform.Translate(0f, 0f, moveAmount);
    }
}























