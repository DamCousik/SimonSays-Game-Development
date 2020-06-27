using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterMovement : MonoBehaviour
{
    public float speed = 7.0f;
    public float height = 5.0f;
    public float plainLeftMax= 1.57f;
    public float plainRightMax = -1.52f;
    public float leftRightSpeed =3.0f ;
    bool left;
    bool right;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;
    public GameObject gameOverPanel;
    public GameObject panelHint;
    public  bool chrctrIsDead = false;
    public Text healthObj;
    public int healthCount = 3;
    private int waitTime;
    public GameObject panelObstacle;
    public GameObject panelLethalObstacle;
    public bool characterIsMoving = false;
    public LetterCollection lc;

    public void Initialize(GameObject character)
    {
        m_animator = character.GetComponent<Animator>();
        m_rigidBody = character.GetComponent<Rigidbody>();
    }

    [SerializeField] private float m_jumpForce = 4;

    [SerializeField] public Animator m_animator;
    [SerializeField] public Rigidbody m_rigidBody;

    private bool m_wasGrounded;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    private bool m_isGrounded;
    private List<Collider> m_collisions = new List<Collider>();

    private void Start()
    {
        #if UNITY_EDITOR
           speed = 6.0f;
        #endif
        waitTime = 210;
    }

    void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    void Update()
    {
       
        waitTime--;
        if (waitTime > 0)
        {
            panelHint.SetActive(true); 
            return;
        }
        if (lc.stop)
        {
            return;
        }
        characterIsMoving = true;
        panelHint.SetActive(false);
        transform.Translate(0, 0, speed * Time.deltaTime);
        Vector3 newRight = new Vector3(plainRightMax, transform.position.y, transform.position.z);
        Vector3 newLeft = new Vector3(plainLeftMax, transform.position.y, transform.position.z);
        if (transform.position.x > 1.52f)
            transform.position = new Vector3(1.52f,transform.position.y,transform.position.z);
        if (transform.position.x < -1.52f)
            transform.position = new Vector3(-1.52f, transform.position.y, transform.position.z);
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
            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKey(KeyCode.Space)))
            {
                //m_rigidBody.velocity = Vector3.zero;
                //m_rigidBody.velocity = Vector3.up * height;
                JumpingAndLanding();
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
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.velocity = Vector3.up * height;
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
        waitTime--;
        if (waitTime > 0)
        {
            panelHint.SetActive(true);
            return;
        }
        panelHint.SetActive(false);
        if(lc.stop)
        {
            return;
        }
        Transform camera = Camera.main.transform;
        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        m_currentV = Mathf.Lerp(m_currentV, 1, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, 1, Time.deltaTime * m_interpolation);

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        m_animator.SetFloat("MoveSpeed", direction.magnitude);
        m_animator.SetBool("Grounded", m_isGrounded);

        JumpingAndLanding();

        m_wasGrounded = m_isGrounded;

        if (!m_isGrounded && transform.position.y < -3)
        {
            if(healthCount < 1)
            {
                chrctrIsDead = true;
                Debug.Log("You are drowning NOW :( ! Sorry, but SimonSays - YOU drown!!");
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.isKinematic = true;
                m_animator.gameObject.SetActive(false);
                healthCount -= 1;
                healthObj.text = "Health : " + healthCount;
                panelObstacle.SetActive(false);
                gameOverPanel.SetActive(true);
            }
            else
            {
                healthCount -= 1;
                healthObj.text = "Health : " + healthCount;
                SceneManager.LoadScene("ArenaZone");
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.UpArrow))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.gameObject.tag == ("Obstacle"))
            {
                Debug.Log("You hit an obstacle - YOU LOSE A LIFE!!");
                panelObstacle.gameObject.SetActive(true);
                StartCoroutine(StopTimeForObstacle());
                healthCount -= 1;
                healthObj.text = "Health : " + healthCount;

                SphereCollider myCollider;
                myCollider = other.gameObject.GetComponent<SphereCollider>();

                if(myCollider)
                    transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 2 * myCollider.radius));

                if (healthCount < 1)
                {
                    chrctrIsDead = true;
                    Debug.Log("You are all out of lives! Sorry, but SimonSays - YOU DIE!!");
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.isKinematic = true;
                    m_animator.gameObject.SetActive(false);
                    healthCount = 0;
                    healthObj.text = "Health : " + healthCount;
                    lc.panelBeforeArenaZone.SetActive(false);
                    lc.panelBeforeStartGame.SetActive(false);
                    lc.panelWrongLetter.SetActive(false);
                    lc.panelExtraLetters.SetActive(false);
                    panelObstacle.gameObject.SetActive(false);
                    gameOverPanel.SetActive(true);
                }
            }
            else if (other.gameObject.CompareTag("LethalObstacle"))
            {
                Debug.Log("You've reached the end of the zone! Goodbye!!");
                chrctrIsDead = true;
                panelLethalObstacle.SetActive(true);
                StartCoroutine(StopTimeForLethalObstacle());
                SceneManager.LoadScene("ArenaZone");
            }
        }
        catch(Exception)
        {
            Debug.Log("Exception with Health!" + healthObj);
        }
        
    }

    private IEnumerator StopTimeForLethalObstacle()
    {
        yield return new WaitForSeconds(10);
        panelLethalObstacle.SetActive(false);
    }

    private IEnumerator StopTimeForObstacle()
    {
        yield return new WaitForSeconds(2);
        panelObstacle.gameObject.SetActive(false);
    }

    public void playAgainUI()
    {
        SceneManager.LoadScene("ArenaZone");
    }

    public void mainMenuUI()
    {
        SceneManager.LoadScene("StartGameScreen");
    }
}
