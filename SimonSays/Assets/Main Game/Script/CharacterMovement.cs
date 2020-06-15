using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float height = 5.0f;
    public float plainLeftMax;
    public float plainRightMax = -1.52f;
    public float leftRightSpeed = 1.57f;
    Rigidbody rigidBody;
    bool left;
    bool right;
    private Animator m_Animator;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        Vector3 newRight = new Vector3(plainRightMax, transform.position.y, transform.position.z);
        Vector3 newLeft = new Vector3(plainLeftMax, transform.position.y, transform.position.z);
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                right = true;
                left = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                right = false;
                left = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.velocity = Vector3.up * height;
            }
            if (left == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newLeft, 3 * leftRightSpeed * Time.deltaTime);
                left = false;
            }
            if (right == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newRight, 3 * leftRightSpeed * Time.deltaTime);
                right = false;
            }
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            bool TWOfinger = Input.touches.Length > 1;
            if (!TWOfinger)
            {

                if (touch.position.magnitude > Screen.width / 2)
                {
                    right = true;
                    left = false;
                }
                if (touch.position.magnitude < Screen.width / 2)
                {
                    right = false;
                    left = true;
                }
            }
            if (TWOfinger)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.velocity = Vector3.up * height;
            }
            if (left == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newLeft, leftRightSpeed * Time.deltaTime);
                left = false;
            }
            if (right == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newRight, leftRightSpeed * Time.deltaTime);
                right = false;
            }

        }

    }
    void FixedUpdate()
    {

        Transform camera = Camera.main.transform;
        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        m_currentV = Mathf.Lerp(m_currentV, 1, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, 1, Time.deltaTime * m_interpolation);

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        m_Animator.SetFloat("MoveSpeed", direction.magnitude);

    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacle")
        { 
            Debug.Log("You hit an obstYOU DIE!!");
            Application.LoadLevel(Application.loadedLevel);
        }
        else if(other.gameObject.tag == "LethalObstacle")
        {
            Debug.Log("You've reached the end of the zone! Goodbye!!");
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }
    }

}
