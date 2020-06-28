using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickZone : MonoBehaviour
{
    GameObject zoneValue;
    public static string zoneTag;
    public static int wordNum;
    //public GameObject[] zones;
    //public GameObject zoneDone;
    public GameObject zoneOneCompleted;
    public GameObject zoneTwoCompleted;
    public GameObject zoneThreeCompleted;
    public GameObject zoneFourCompleted;

    public GameObject zoneOneWord;
    public GameObject zoneTwoWord;
    public GameObject zoneThreeWord;
    public GameObject zoneFourWord;


    private void Awake()
    {
        zoneOneWord = GameObject.Find("z1Word");
        zoneTwoWord = GameObject.Find("z2Word");
        zoneThreeWord = GameObject.Find("z3Word");
        zoneFourWord = GameObject.Find("z4Word");
    }
    private void Update()
        {
            if(LetterCollection.zoneState.Count > 0)
            {
                foreach (KeyValuePair<GameObject, bool> kvp in LetterCollection.zoneState)
                {
                //Debug.Log(" Key = " + kvp.Key);
                //Debug.Log(" Value = " + kvp.Value);

                    if (kvp.Key.CompareTag("z1"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompleted.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key.CompareTag("z2"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompleted.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key.CompareTag("z3"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompleted.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key.CompareTag("z4"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompleted.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                }
                     //if (kvp.Value == true)
                     //{
                     //       zoneOneCompleted.gameObject.SetActive(true);
                            
                     //       //kvp.Key.GetComponent<MeshRenderer>().material.color = Color.green;
                     //       //kvp.Key.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                     //       //DontDestroyOnLoad(kvp.Key);
                     //       //Debug.Log("Color is successfully changed!! ---- " + kvp.Key.GetComponent<MeshRenderer>().material.color);
                     //}
                    
            }
            

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("Doing Ray test");
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        zoneTag = hit.collider.gameObject.tag;
                        DontDestroyOnLoad(hit.collider.gameObject);

                        wordNum = zoneTag[1] - '0' - 1;

                        Debug.Log("Hit Somthing" + hit.transform.tag);
                        if (hit.collider.gameObject.name == "zone1")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-A-Screen");
                        }
                        else if (hit.collider.gameObject.name == "zone2")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-B-Screen");
                        }
                        else if (hit.collider.gameObject.name == "zone3")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-C-Screen");
                        }
                        else if (hit.collider.gameObject.name == "zone4")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-D-Screen");
                        }
                        else
                            Debug.Log("You've clicked a zone that doesn't belong to our world!!");
                    }
                }
            }
        }