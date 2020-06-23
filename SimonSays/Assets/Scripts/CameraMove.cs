
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

		system = SystemInfo.operatingSystem;
		if (system.Contains("Windows"))
			waitTime = 170;
		else
			waitTime = 85;
	}

	void FixedUpdate()
    {
		waitTime--;
		if (waitTime > 0)
		{
			return;
		}

		CharacterMovement tryM = character.GetComponent<CharacterMovement>();
	    if (!tryM.chrctrIsDead)
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























