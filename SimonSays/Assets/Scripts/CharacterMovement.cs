﻿using System.Collections;
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
    public float plainLeftMax = 1.57f;
    public float plainRightMax = -1.52f;
    public float leftRightSpeed = 3.0f;
    bool left = false;
    bool right = false;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private readonly float m_interpolation = 10;
    public GameObject gameOverPanel;
    public GameObject panelHint;
    public bool chrctrIsDead = false;
    public int healthCount = 3;
    public GameObject panelObstacle;
    public GameObject panelpause;
    public GameObject panelLethalObstacle;
    public GameObject panelExit;
    public GameObject panelHealth;
    public bool characterIsMoving = false;
    public LetterCollection lc;
    public ParticleSystem ps;
    bool started;
    bool health=false;
    public Scrollbar hb;
    bool avoidHint = false;
    float myPos = 0;
    float touchMagnitude;
    float touchBx, touchBy, touchEx, touchEy;
    bool characterStateBeforeQuit;
    float timer;

    //sound
    public AudioClip Obst_impact;
    public AudioClip Die;
    private AudioSource audio1;
    private AudioSource audio2;
    bool isMute;

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
        health = false;
        panelHealth.SetActive(true);
        #if UNITY_EDITOR
        speed = 6.0f;
        #endif
        started = false;

        //sounds
        audio1 = GetComponent<AudioSource>();
        audio2 = GetComponent<AudioSource>();
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
        lc.stop = false;
    }

    public void resumePause()
    {
        lc.stop = false;
        characterIsMoving = true;
        panelpause.SetActive(false);
    }

    public void resumeOnClick()
    {
        Debug.Log("Resume Button : Resume False"); 
        characterIsMoving = characterStateBeforeQuit;
        if ((characterIsMoving) && (!panelLethalObstacle.activeSelf))
            lc.stop = false;
        else
            lc.stop = true;
        panelExit.SetActive(false);
        Debug.Log("Resume Button : Resume True");
    }

    public void pauseZone()
    {
        if (characterIsMoving)
        {
            Debug.Log("Paused Clicked");
            lc.stop = true;
            m_rigidBody.velocity = Vector3.zero;
            characterIsMoving = false;
            panelpause.SetActive(true);
            Debug.Log("Paused Clicked : Resume set to false");
        }
    }

    void Update()
    {
        if(!health)
        {
            return;
        }
        if (!started)
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
        if (transform.position.x > 1.52f)
            transform.position = new Vector3(1.52f, transform.position.y, transform.position.z);
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
                JumpingAndLanding(false);
            }
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
        if (Input.touchCount > 0)
        {
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
                    print("right true");
                }
                if (touchBx - touchEx > 100)
                {
                    right = false;
                    left = true;
                    print("Left true");
                }
                if (Mathf.Abs(touchEy - touchBy) > 200)
                {
                    JumpingAndLanding(true);
                }
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
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (!health)
        {          
            StartCoroutine(StopTimeForHealth());         
            return;
        }
        if (!started)
        {
            panelHint.SetActive(true);
            return;
        }

        if (lc.stop)
        {
            return;
        }

        panelHint.SetActive(false);
        characterIsMoving = true;
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
        //Drowning handling
        if (!m_isGrounded && transform.position.y < -3)
        {
            if (healthCount < 1)
            {
                chrctrIsDead = true;
                Debug.Log("You are drowning NOW :( ! Sorry, but SimonSays - YOU drown!!");
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.isKinematic = true;
                m_animator.gameObject.SetActive(false);
                healthCount -= 1;
                panelObstacle.SetActive(false);
                gameOverPanel.SetActive(true);
            }
            else
            {
                healthCount -= 1;
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
        try
        {
            if (other.gameObject.tag == ("Obstacle"))
            {
                Debug.Log("You hit an obstacle - YOU LOSE A LIFE!!");
                //Sound
                audio1.PlayOneShot(Obst_impact, 0.1F);

                panelObstacle.gameObject.SetActive(true);
                StartCoroutine(StopTimeForObstacle());
                healthCount -= 1;
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
                ps.Play();
                StartCoroutine(ChangeSize());
                SphereCollider myCollider;
                myCollider = other.gameObject.GetComponent<SphereCollider>();
                if (myCollider)
                    transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - 2 * myCollider.radius));

                if (healthCount < 1)
                {
                    hb.gameObject.SetActive(false);
                    chrctrIsDead = true;
                    Debug.Log("You are all out of lives! Sorry, but SimonSays - YOU DIE!!");
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.isKinematic = true;
                    m_animator.gameObject.SetActive(false);
                    healthCount = 0;
                    lc.panelBeforeArenaZone.SetActive(false);
                    lc.panelWrongLetter.SetActive(false);
                    panelObstacle.gameObject.SetActive(false);
                    gameOverPanel.SetActive(true);
                }
            }
            else if (other.gameObject.CompareTag("LethalObstacle"))
            {
                Debug.Log("You've reached the end of the zone! Goodbye!!");
                chrctrIsDead = true;
                //sound
                audio2.PlayOneShot(Die, 0.7F);
                panelLethalObstacle.SetActive(true);
                lc.stop = true;
            }

        }
        catch (Exception)
        {
            Debug.Log("Exception with Health!");
        }

    }

    //mute button function
    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    private IEnumerator StopTimeForHealth()
    { 
        panelHealth.transform.Find("Red").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        panelHealth.transform.Find("Red").gameObject.SetActive(false);
        panelHealth.transform.Find("Yellow").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        panelHealth.transform.Find("Yellow").gameObject.SetActive(false);
        panelHealth.transform.Find("Green").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        closeHealth();        
    }
    public void closeHealth()
    {
        panelHealth.SetActive(false);
        health = true;
    }

    private IEnumerator StopTimeForObstacle()
    {
        yield return new WaitForSeconds(2);
        panelObstacle.gameObject.SetActive(false);
    }
    public IEnumerator ChangeSize()
    {
        Vector3 add = new Vector3(1, 3.5f, 1);
        transform.localScale = add;
        yield return new WaitForSeconds(0.1f);
        ps.Stop();
        transform.localScale = new Vector3(1, 1.3f, 1);
    }
    public void playAgainUI()
    {
        SceneManager.LoadScene("Level");
    }
    public void playAgainLethal()
    {
        if (ClickZone.zoneTag == "Zone 1")
        {
            SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[0] + "-Screen");
        }
        else if (ClickZone.zoneTag == "Zone 2")
        {
            SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[1] + "-Screen");
        }
        else if (ClickZone.zoneTag == "Zone 3")
        {
            SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[2] + "-Screen");
        }
        else if (ClickZone.zoneTag == "Zone 4")
        {
            SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[3] + "-Screen");
        }
        else if (ClickZone.zoneTag == "Zone 5")
        {
            SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[4] + "-Screen");
        }
    }

    public void mainMenuUI()
    {
        SceneManager.LoadScene("StartGameScreen");
    }

    public void arenaUI()
    {
        SceneManager.LoadScene("ArenaZone");
    }

    public void quitButtonOnClick()
    {
        lc.stop = true;
        m_rigidBody.velocity = Vector3.zero;
        characterStateBeforeQuit = characterIsMoving;
        characterIsMoving = false;
        panelExit.SetActive(true);
    }
}
