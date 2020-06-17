
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed;
	public GameObject mainCamera;
	GameObject character;

	// Use this for initialization
	void Start () {
		mainCamera.transform.localPosition = new Vector3 ( 0, 0, 0 );
		mainCamera.transform.localRotation = Quaternion.Euler (18, 180, 0);
		character = GameObject.Find("MaleFreeSimpleMovement1");

		//StartCoroutine(cameraCoroutine());
	}

    void FixedUpdate()
    {
	    CharacterMovement tryM = character.GetComponent<CharacterMovement>();
	    if (!tryM.chrctrIsDead)
	    {
		    //print("Nice woke FINE");
		    MoveObj();
	    }
        
    }

    //IEnumerator cameraCoroutine()
    //   {
    //	yield return new WaitForSeconds(5);
    //}

    void MoveObj()
    {
        float moveAmount = Time.smoothDeltaTime * moveSpeed;
        transform.Translate(0f, 0f, moveAmount);
    }

 //   private void LateUpdate()
 //   {
	//	Vector3 cameraPosition = new Vector3(0, 3, (character.transform.position.z - 15));
	//	transform.position = cameraPosition;

	//}
}























