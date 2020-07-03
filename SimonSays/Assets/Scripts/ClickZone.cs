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
    public string diff;
    
    //For 3 and 5 zones
    public GameObject zoneOneCompleted;
    public GameObject zoneTwoCompleted;
    public GameObject zoneThreeCompleted;
    public GameObject zoneFourCompleted;
    public GameObject zoneFiveCompleted;

    public GameObject zoneOne;
    public GameObject zoneTwo;
    public GameObject zoneThree;
    public GameObject zoneFour;
    public GameObject zoneFive;

    public GameObject zoneOneWord;
    public GameObject zoneTwoWord;
    public GameObject zoneThreeWord;
    public GameObject zoneFourWord;
    public GameObject zoneFiveWord;


    public GameObject zoneOneCompletedFour;
    public GameObject zoneTwoCompletedFour;
    public GameObject zoneThreeCompletedFour;
    public GameObject zoneFourCompletedFour;

    public GameObject zoneOneFour;
    public GameObject zoneTwoFour;
    public GameObject zoneThreeFour;
    public GameObject zoneFourFour;

    public GameObject zoneOneWordFour;
    public GameObject zoneTwoWordFour;
    public GameObject zoneThreeWordFour;
    public GameObject zoneFourWordFour;

    public GameObject menuBar;
    public GameObject levelBar;


    public GameObject panelWinEasy;
    public GameObject panelWinMedium;
    public GameObject panelWinHard;
    public GameObject panelWinExtreme;



    public void Start()
    {
        menuBar.gameObject.SetActive(true);
        levelBar.gameObject.SetActive(true);

        if(Sentence.wordCount == 3)  
            {
                zoneOne.SetActive(true);
                zoneOneWord.gameObject.SetActive(true);
                zoneTwo.SetActive(true);
                zoneTwoWord.gameObject.SetActive(true);
                zoneThree.SetActive(true);
                zoneThreeWord.gameObject.SetActive(true);
                
            }

            if(Sentence.wordCount == 4) 
            {
                zoneOneFour.SetActive(true);
                zoneOneWordFour.gameObject.SetActive(true);
                zoneTwoFour.SetActive(true);
                zoneTwoWordFour.gameObject.SetActive(true);
                zoneThreeFour.SetActive(true);
                zoneThreeWordFour.gameObject.SetActive(true);
                zoneFourFour.SetActive(true);
                zoneFourWordFour.gameObject.SetActive(true);

            }

            if(Sentence.wordCount == 5)  
            {
                zoneOne.SetActive(true);
                zoneOneWord.gameObject.SetActive(true);
                zoneTwo.SetActive(true);
                zoneTwoWord.gameObject.SetActive(true);
                zoneThree.SetActive(true);
                zoneThreeWord.gameObject.SetActive(true);
                zoneFour.SetActive(true);
                zoneFourWord.gameObject.SetActive(true);
                zoneFive.SetActive(true);
                zoneFiveWord.gameObject.SetActive(true);
               
            }

    }


    private void Update()
    {
        diff = LevelDifficulty.difficulty;

        //Easy : words = 3 and Level = easy
        if(diff == "Easy")
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
                }        
            }
            //Easy  
            if (zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf)
                {
                    panelWinEasy.gameObject.SetActive(true);
                }
        } 
        //easy ends


        //Medium : words = 4 and Level = Medium
        if(diff == "Medium")
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
                            zoneOneCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key.CompareTag("z2"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key.CompareTag("z3"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key.CompareTag("z4"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                }                   
            }

            if(zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf 
                && zoneFourCompleted.gameObject.activeSelf)
                
                {
                    panelWinMedium.gameObject.SetActive(true);
                }
        }
        //medium ends



        //Hard : Word count = 5 and level = hard
        if(diff == "Hard")
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
                    //
                    else if (kvp.Key.CompareTag("z5"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneFiveCompleted.gameObject.SetActive(true);
                            Destroy(zoneFiveWord);
                        }
                    }
                }                
            }  
            if(zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf 
                && zoneFourCompleted.gameObject.activeSelf
                && zoneFiveCompleted.gameObject.activeSelf)
                {
                    panelWinHard.gameObject.SetActive(true);
                }

        }
        //Hard ends




        //Extreme : Level : Extreme words : 3,4,5
        if(diff == "Extreme")
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
                    //
                    else if (kvp.Key.CompareTag("z5"))
                    {
                        if (kvp.Value == true)
                        {
                            zoneFiveCompleted.gameObject.SetActive(true);
                            Destroy(zoneFiveWord);
                        }
                    }
                }                
            }
            if(Sentence.wordCount == 3 
                && zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf)
                {
                    panelWinExtreme.gameObject.SetActive(true);
                }

            if(Sentence.wordCount == 4 
                && zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf 
                && zoneFourCompleted.gameObject.activeSelf)
                {
                    panelWinExtreme.gameObject.SetActive(true);
                } 

            if(Sentence.wordCount == 5 
                && zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf 
                && zoneFourCompleted.gameObject.activeSelf
                && zoneFiveCompleted.gameObject.activeSelf)
                {
                    panelWinExtreme.gameObject.SetActive(true);
                }
        }
        //extreme ends 


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

                        if (hit.collider.gameObject.tag == "z1")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-A-Screen");
                        }
                        else if (hit.collider.gameObject.tag == "z2")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-B-Screen");
                        }
                        else if (hit.collider.gameObject.tag == "z3")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-C-Screen");
                        }
                        else if (hit.collider.gameObject.tag == "z4")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-D-Screen");
                        }
                        //
                        else if (hit.collider.gameObject.tag == "z5")
                        {
                            zoneValue = hit.collider.gameObject;
                            SceneManager.LoadScene("Zone-A-Screen");
                            //A for now
                        }
                        //

                        else
                            Debug.Log("You've clicked a zone that doesn't belong to our world!!");
                    }
                }
            }


        public void menuBarUI()
    {
        SceneManager.LoadScene("StartGameScreen");
    }

    public void levelBarUI()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void levelEasyUI()
    {
        SceneManager.LoadScene("Level");
    }

    public void levelMediumUI()
    {
        SceneManager.LoadScene("Level");
    }

    public void levelHardUI()
    {
        SceneManager.LoadScene("Level");
    }

    public void levelExtremeUI()
    {
        SceneManager.LoadScene("Level");
    }



}
    