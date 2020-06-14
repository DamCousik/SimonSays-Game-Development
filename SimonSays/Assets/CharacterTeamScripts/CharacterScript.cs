using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;


public class CharacterScript : MonoBehaviour
{
   
    float speed = 5.0f;
    float height = 5.0f;
    Rigidbody rigidBody;
    bool left;
    bool right;
    int WrongLettersCollected;
    private Vector3 m_Move;
    private Animator m_Animator;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10; 
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        WrongLettersCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        Vector3 newRight = new Vector3( 8.2f, transform.position.y, transform.position.z);
        Vector3 newLeft = new Vector3(-8.2f, transform.position.y,transform.position.z);
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
            else
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.velocity = Vector3.up * height;
            }
            if (left == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newLeft, speed*Time.deltaTime);
            }
            if (right == true)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, newRight, speed*Time.deltaTime);
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


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Correct")
        {
            Destroy(other.gameObject);
            Debug.Log("Correct letter collected");
        }

        if(other.gameObject.tag=="Incorrect")
        {
            Destroy(other.gameObject);
            WrongLettersCollected++;
            Debug.Log("Wrong letter collected");
        }
        if(other.gameObject.tag=="Obstacle")
        {
            //Rotation code
            Destroy(other.gameObject);
            Debug.Log("Obstacle collected");
        }
    }

}
