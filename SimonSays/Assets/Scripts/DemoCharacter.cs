using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DemoCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    public float height = 5.0f;
    public float plainLeftMax = 1.57f;
    public float plainRightMax = -1.52f;
    public float leftRightSpeed = 3.0f;
    bool left = false;
    bool right = false;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;
    public bool chrctrIsDead = false;
    public int healthCount = 3;
    public bool characterIsMoving = false;
    public ParticleSystem ps;
    bool started;
    bool stop = false;
    public Scrollbar hb;
    bool avoidHint = false;
    float myPos = 0;
    float touchMagnitude;
    float touchBx, touchBy, touchEx, touchEy;
    public GameObject panelHint;
    public GameObject CorrectPanel;
    public GameObject IncorrectPanel;
    public GameObject PanelCorrectLetter;
    public GameObject PanelWrongLetter;
    public GameObject Congratulations;
    public GameObject MissLetter;
    public GameObject PanelObstacle;
    public GameObject PanelLethalObstacle;
    public GameObject Incorrect3;
    public GameObject OutOfLives;
    public GameObject Display;
    string collected="";
    int countWrong = 0;
    int displayHint = 4;
    float Timer;
    bool x=false;
    bool waitingForRight = false, waitingForLeft=false, waitingForUp=false;
    //public DemoImages d;

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
        speed = 5.0f;
     #endif
        started = false;
    }
    void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }
    public void hintClick()
    {
        started = true;
        avoidHint = true;
    }
    void Update()
    {
        int keyOrTouch = 0;
        if (!started)
        {
            panelHint.SetActive(true);
            return;
        }
        if (Input.anyKey)
        {
            keyOrTouch = 1;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                right = true;
                left = false;              
                if(x && waitingForRight)
                {
                    print("From right");
                    Display.SetActive(false);
                    stop = false;
                    characterIsMoving = true;
                    displayHint--;
                }
                waitingForRight = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                right = false;
                left = true;              
                if (x && waitingForLeft)
                {
                    print("From left");
                    Display.SetActive(false);
                    stop = false;
                    characterIsMoving = true;
                    displayHint--;
                }
                waitingForLeft = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKey(KeyCode.Space)))
            {
                if (x && waitingForUp)
                {
                    print("From Up");
                    Display.SetActive(false);
                    stop = false;
                    characterIsMoving = true;
                    displayHint--;
                }
                JumpingAndLanding(false);
                waitingForUp = false;
            }
        }
        if (Input.touchCount > 0)
        {
            keyOrTouch = 2;
            if (avoidHint)
            {
                avoidHint = false;
                return;
            }
            print("right val before:" + right);
            print("left val before:" + left);
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchMagnitude = touch.position.magnitude;
                touchBy = touch.position.y;
                touchBx = touch.position.x;
                return;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchEy = touch.position.y;
                touchEx = touch.position.x;
                if (touchEx - touchBx > 100)
                {
                    right = true;
                    left = false;
                    if (x && waitingForRight)
                    {
                        print("From right");
                        Display.SetActive(false);
                        stop = false;
                        characterIsMoving = true;
                        displayHint--;
                    }
                    waitingForRight = false;
                }
                if (touchBx - touchEx > 100)
                {
                    right = false;
                    left = true;
                    if (x && waitingForLeft)
                    {
                        print("From left");
                        Display.SetActive(false);
                        stop = false;
                        characterIsMoving = true;
                        displayHint--;
                    }
                    waitingForLeft = false;
                }
                if (Mathf.Abs(touchEy - touchBy) > 200)
                {
                    if (x && waitingForUp)
                    {
                        print("From Up");
                        Display.SetActive(false);
                        stop = false;
                        characterIsMoving = true;
                        displayHint--;
                    }
                    JumpingAndLanding(true);
                    waitingForUp = false;
                }
            }
        }
        if (stop)
        {
            right = false;
            left = false;
            return;
        }
        characterIsMoving = true;
        panelHint.SetActive(false);    
        transform.Translate(0, 0, speed * Time.deltaTime);
        if(keyOrTouch==1)
        { 
            if (left == true)
            {
                float checkMin = Mathf.Min(transform.position.x + 1, 1);
                transform.position = new Vector3(checkMin, transform.position.y, transform.position.z);
                left = false;
            }
            if (right == true)
            {
                float checkMax = Mathf.Max(transform.position.x - 1, -1);
                transform.position = new Vector3(checkMax, transform.position.y, transform.position.z);
                right = false;
            }
        }
        if(keyOrTouch==2)
        {
                if (left == true)
                {
                    float checkMin = Mathf.Min(myPos + 1, 1);
                    transform.position = new Vector3(checkMin, transform.position.y, transform.position.z);
                    myPos = checkMin;
                    left = false;
                }
                if (right == true)
                {
                    float checkMax = Mathf.Max(myPos - 1, -1);
                    transform.position = new Vector3(checkMax, transform.position.y, transform.position.z);
                    myPos = checkMax;
                    right = false;
                }
            
        }
    }
    void FixedUpdate()
    {     
        if (!started)
        {
            panelHint.SetActive(true);
            return;
        }
        if (stop)
        {
            return;
        }
        panelHint.SetActive(false);
        characterIsMoving = true;
        Timer += Time.deltaTime;
        if (displayHint > 0 && Timer>2)
        {
            displayHints();          
        }
        //Animation
        Transform camera = Camera.main.transform;
        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;
        m_currentV = Mathf.Lerp(m_currentV, 1, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, 1, Time.deltaTime * m_interpolation);
        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;
        m_animator.SetFloat("MoveSpeed", direction.magnitude);
        m_animator.SetBool("Grounded", m_isGrounded);
        m_wasGrounded = m_isGrounded;
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

    private void JumpingAndLanding(bool mobile)
    {

        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (mobile && jumpCooldownOver && m_isGrounded)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
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
        if (other.gameObject.tag == ("LethalObstacle"))
        {
            PanelLethalObstacle.SetActive(true);
            hb.gameObject.SetActive(false);
            chrctrIsDead = true;
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.isKinematic = true;
            m_animator.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == ("Obstacle"))
        {
            Debug.Log("You hit an obstacle - YOU LOSE A LIFE!!");
            PanelObstacle.gameObject.SetActive(true);
            StartCoroutine(StopTimeForObstacle());
            healthCount -= 1;
            ps.Play();
            StartCoroutine(ChangeSize());
            if (healthCount == 2)
            {
                hb.size = 0.6f;
                hb.targetGraphic.color = Color.yellow;
            }
            if (healthCount == 1)
            {
                hb.size = 0.2f;
                hb.targetGraphic.color = Color.red;
            }
            if(healthCount<1)
            {
                hb.gameObject.SetActive(false);
                chrctrIsDead = true;
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.isKinematic = true;
                m_animator.gameObject.SetActive(false);
                OutOfLives.SetActive(true);
            }
           
        }
        if (other.gameObject.tag == ("J")|| other.gameObject.tag == ("A")|| other.gameObject.tag == ("W")|| other.gameObject.tag == ("S"))
        {
            PanelCorrectLetter.gameObject.SetActive(true);
            stop = true;
            characterIsMoving = false;          
            collected = collected +other.gameObject.tag;
            StartCoroutine(StopTimeForObstacle());
            if (collected.Contains("J") && collected.Contains("A") && collected.Contains("W") && collected.Contains("S"))
            {
                hb.gameObject.SetActive(false);
                chrctrIsDead = true;
                stop = true;
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.isKinematic = true;
                m_animator.gameObject.SetActive(false);
                Congratulations.gameObject.SetActive(true);
            }           
            Destroy(other.gameObject);
            if (other.gameObject.tag == ("J"))
                CorrectPanel.gameObject.transform.Find("J").transform.Find("Text").GetComponent<Text>().text = "J";
            if (other.gameObject.tag == ("A"))
                CorrectPanel.gameObject.transform.Find("A").transform.Find("Text").GetComponent<Text>().text = "A"; 
            if (other.gameObject.tag == ("W"))
                CorrectPanel.gameObject.transform.Find("W").transform.Find("Text").GetComponent<Text>().text = "W"; 
            if (other.gameObject.tag == ("S"))
                CorrectPanel.gameObject.transform.Find("S").transform.Find("Text").GetComponent<Text>().text = "S";

        }
        if (other.gameObject.tag == ("B") || other.gameObject.tag == ("C") || other.gameObject.tag == ("L") || other.gameObject.tag == ("G"))
        {
            countWrong++;
            PanelWrongLetter.gameObject.SetActive(true);
            stop = true;
            characterIsMoving = false;
            StartCoroutine(StopTimeForObstacle());
            Destroy(other.gameObject);
            if (other.gameObject.tag == ("B"))
                IncorrectPanel.gameObject.transform.Find("B").gameObject.SetActive(true);
            if (other.gameObject.tag == ("C"))
                IncorrectPanel.gameObject.transform.Find("C").gameObject.SetActive(true);
            if (other.gameObject.tag == ("L"))
                IncorrectPanel.gameObject.transform.Find("L").gameObject.SetActive(true);
            if (other.gameObject.tag == ("G"))
                IncorrectPanel.gameObject.transform.Find("G").gameObject.SetActive(true);
            if(countWrong==3)
            {
                Incorrect3.SetActive(true);
                stop = true;
                characterIsMoving = false;
            }
        }
        if(other.gameObject.tag==("Test") && collected=="")
        {
            MissLetter.SetActive(true);
            hb.gameObject.SetActive(false);
            chrctrIsDead = true;
            stop = true;
            characterIsMoving = false;
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.isKinematic = true;
            m_animator.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == ("WTest") && !collected.Contains("W"))
        {
            MissLetter.SetActive(true);
            hb.gameObject.SetActive(false);
            chrctrIsDead = true;
            stop = true;
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.isKinematic = true;
            m_animator.gameObject.SetActive(false);
            characterIsMoving = false;
        }
        if (other.gameObject.tag == ("ATest") && !collected.Contains("A"))
        {
            MissLetter.SetActive(true);
            hb.gameObject.SetActive(false);
            chrctrIsDead = true;
            stop = true;
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.isKinematic = true;
            m_animator.gameObject.SetActive(false);
            characterIsMoving = false;
        }
        if (other.gameObject.tag == ("STest") && !collected.Contains("S"))
        {
            MissLetter.SetActive(true);
            hb.gameObject.SetActive(false);
            chrctrIsDead = true;
            stop = true;
            m_rigidBody.velocity = Vector3.zero;
            m_rigidBody.isKinematic = true;
            m_animator.gameObject.SetActive(false);
            characterIsMoving = false;
        }
    }
    public void displayHints()
    {
        Display.transform.Find("Right").GetComponent<Image>().gameObject.SetActive(false);
        Display.transform.Find("Left").GetComponent<Image>().gameObject.SetActive(false);
        Display.transform.Find("Up").GetComponent<Image>().gameObject.SetActive(false);
        stop = true;
        m_rigidBody.velocity = Vector3.zero;
        characterIsMoving = false;
        Display.SetActive(true);
        if(displayHint==4)
        {
            Display.transform.Find("Text").GetComponent<Text>().text = "To Move Right: Swipe Right or click ";
            Display.transform.Find("Right").GetComponent<Image>().gameObject.SetActive(true);
            Timer -= 1;
            waitingForRight = true;
            x = true;
        }
        if (displayHint == 2 || displayHint==3)
        {
            Display.transform.Find("Text").GetComponent<Text>().text = "To Move Left: Swipe Left or click ";       
            Display.transform.Find("Left").GetComponent<Image>().gameObject.SetActive(true);
            Timer -= 1.2f;
            waitingForLeft = true;
            x = true;
        }
        if (displayHint == 1)
        {
            Display.transform.Find("Text").GetComponent<Text>().text = "To Jump: Swip Up or ";
            Timer -= 2;
            Display.transform.Find("Up").GetComponent<Image>().gameObject.SetActive(true);
            waitingForUp = true;
            x = true;
        }
    }
    public IEnumerator ChangeSize()
    {
        Vector3 add = new Vector3(1, 3.5f, 1);
        transform.localScale = add;
        yield return new WaitForSeconds(0.1f);
        ps.Stop();
        transform.localScale = new Vector3(1, 1.3f, 1);
    }
    public void playAgain()
    {
        SceneManager.LoadScene("Demo");
    }
    public void chooseDifficulty()
    {
        SceneManager.LoadScene("DemoJumble");
    }
    private IEnumerator StopTimeForObstacle()
    {
        yield return new WaitForSeconds(3);
        PanelObstacle.gameObject.SetActive(false);
        PanelCorrectLetter.gameObject.SetActive(false);
        PanelWrongLetter.gameObject.SetActive(false);
        stop = false;
        characterIsMoving = true;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("StartGameScreen");
    }
}