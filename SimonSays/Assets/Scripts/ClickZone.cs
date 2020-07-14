using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickZone : MonoBehaviour
{
    GameObject zoneValue;
    public static string zoneTag;
    public static int wordNum;
    public string diff;
    public GameObject fireworks;
    
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

    public GameObject levelBar;

    public GameObject panelWin;

    public void Start()
    { 
        levelBar.gameObject.SetActive(true);
        fireworks.gameObject.SetActive(false);

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
                foreach (KeyValuePair<string, bool> kvp in LetterCollection.zoneState)
                {

                    if (kvp.Key == "Zone 1")
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompleted.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key == "Zone 2")
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompleted.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key == "Zone 3")
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
                    panelWin.gameObject.SetActive(true);
                    fireworks.gameObject.SetActive(true);
            }
        }
        //easy ends

        //Medium : words = 4 and Level = Medium
        if(diff == "Medium")
        {
             if(LetterCollection.zoneState.Count > 0)
            {
                foreach (KeyValuePair<string, bool> kvp in LetterCollection.zoneState)
                {

                    if (kvp.Key == "Zone 1")
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key == "Zone 2")
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key == "Zone 3")
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key == "Zone 4")
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                }
            }

            if(zoneOneCompletedFour.gameObject.activeSelf 
                && zoneTwoCompletedFour.gameObject.activeSelf 
                && zoneThreeCompletedFour.gameObject.activeSelf 
                && zoneFourCompletedFour.gameObject.activeSelf)
                
                {
                    panelWin.gameObject.SetActive(true);
                    fireworks.gameObject.SetActive(true);
            }
        }
        //medium ends

        //Hard : Word count = 5 and level = hard
        if(diff == "Hard")
        {
            if(LetterCollection.zoneState.Count > 0)
            {
                foreach (KeyValuePair<string, bool> kvp in LetterCollection.zoneState)
                {
                    if (kvp.Key == "Zone 1")
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompleted.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key == "Zone 2")
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompleted.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key == "Zone 3")
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompleted.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key == "Zone 4")
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompleted.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                    //
                    else if (kvp.Key == "Zone 5")
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
                    panelWin.gameObject.SetActive(true);
                fireworks.gameObject.SetActive(true);
            }
        }
        //Hard ends

        //Extreme : Level : Extreme words : 3,5
        if(diff == "Extreme" && (Sentence.wordCount == 3 || Sentence.wordCount == 5 ))
        {
            if(LetterCollection.zoneState.Count > 0)
            {
                foreach (KeyValuePair<string, bool> kvp in LetterCollection.zoneState)
                {

                    if (kvp.Key == "Zone 1")
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompleted.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }   
                    }
                    else if (kvp.Key == "Zone 2")
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompleted.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key == "Zone 3")
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompleted.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key == "Zone 4")
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompleted.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                    else if (kvp.Key == "Zone 5")
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
                    panelWin.gameObject.SetActive(true);
                fireworks.gameObject.SetActive(true);
            }

            if(Sentence.wordCount == 5 
                && zoneOneCompleted.gameObject.activeSelf 
                && zoneTwoCompleted.gameObject.activeSelf 
                && zoneThreeCompleted.gameObject.activeSelf 
                && zoneFourCompleted.gameObject.activeSelf
                && zoneFiveCompleted.gameObject.activeSelf)
                {
                    panelWin.gameObject.SetActive(true);
                    fireworks.gameObject.SetActive(true);
            }
        }
        //extreme ends 

        //Extreme : Level : Extreme words : 4
        if(diff == "Extreme" && Sentence.wordCount == 4 )
        {
            if(LetterCollection.zoneState.Count > 0)
            {
                foreach (KeyValuePair<string, bool> kvp in LetterCollection.zoneState)
                {

                    if (kvp.Key == "Zone 1")
                    {
                        if (kvp.Value == true)
                        {
                            zoneOneCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneOneWord);
                        }
                    }
                    else if (kvp.Key == "Zone 2")
                    {
                        if (kvp.Value == true)
                        {
                            zoneTwoCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneTwoWord);
                        }
                    }
                    else if (kvp.Key == "Zone 3")
                    {
                        if (kvp.Value == true)
                        {
                            zoneThreeCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneThreeWord);
                        }
                    }
                    else if (kvp.Key == "Zone 4")
                    {
                        if (kvp.Value == true)
                        {
                            zoneFourCompletedFour.gameObject.SetActive(true);
                            Destroy(zoneFourWord);
                        }
                    }
                }
            }

            if(zoneOneCompletedFour.gameObject.activeSelf 
                && zoneTwoCompletedFour.gameObject.activeSelf 
                && zoneThreeCompletedFour.gameObject.activeSelf 
                && zoneFourCompletedFour.gameObject.activeSelf)

            {
                panelWin.gameObject.SetActive(true);
                fireworks.gameObject.SetActive(true);
            }
        }


        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Doing Ray test");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                zoneTag = hit.collider.gameObject.tag;
                //DontDestroyOnLoad(GameObject.FindWithTag(zoneTag));

                wordNum = zoneTag[5] - '0' - 1;

                if (hit.collider.gameObject.tag == "Zone 1" && !(LetterCollection.zoneState.ContainsKey("Zone 1")))
                {
                    zoneValue = hit.collider.gameObject;
                    SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[0] + "-Screen");
                }
                else if (hit.collider.gameObject.tag == "Zone 2" && !(LetterCollection.zoneState.ContainsKey("Zone 2")))
                {
                    zoneValue = hit.collider.gameObject;
                    SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[1] + "-Screen");
                }
                else if (hit.collider.gameObject.tag == "Zone 3" && !(LetterCollection.zoneState.ContainsKey("Zone 3")))
                {
                    zoneValue = hit.collider.gameObject;
                    SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[2] + "-Screen");
                }
                else if (hit.collider.gameObject.tag == "Zone 4" && !(LetterCollection.zoneState.ContainsKey("Zone 4")))
                {
                    zoneValue = hit.collider.gameObject;
                    SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[3] + "-Screen");
                }
                else if (hit.collider.gameObject.tag == "Zone 5" && !(LetterCollection.zoneState.ContainsKey("Zone 5")))
                {
                    zoneValue = hit.collider.gameObject;
                    SceneManager.LoadScene("Zone-" + SentenceJumble.loadZoneScenes[4] + "-Screen");
                }
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

    public void levelWin()
    {
        SceneManager.LoadScene("Level");
    }

}