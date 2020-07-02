
using UnityEngine;
using System.Collections;

public class DemoCamera : MonoBehaviour
{

	public float moveSpeed = -7.0f;
	private string system;
	public GameObject mainCamera;
	GameObject character;

	void Start()
	{
		mainCamera.transform.localPosition = new Vector3(0, 0, 0);
		mainCamera.transform.localRotation = Quaternion.Euler(18, 180, 0);
		character = GameObject.Find("MaleFreeSimpleMovement1");

#if UNITY_EDITOR
		moveSpeed = -6.0f;
#endif
	}

	void FixedUpdate()
	{

		DemoCharacter demo = character.GetComponent<DemoCharacter>();
		if (!demo.chrctrIsDead && demo.characterIsMoving)
		{
			print("character Moving");
			MoveObj();
		}
	}

	void MoveObj()
	{
		float moveAmount = Time.smoothDeltaTime * moveSpeed;
		transform.Translate(0f, 0f, moveAmount);
	}
}























