using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterCollection : MonoBehaviour
{
    public Dictionary<string, int> charValueFrequencies = new Dictionary<string, int>();
    public Dictionary<string, int> charWordFrequencies = new Dictionary<string, int>();
    public List<string> collectedLetters = new List<string>();
    public int countIncorrectLetters = 0;
    public int countCorrectLetters = 0;
    public int healthCount = 3;
    public Text healthObj;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    int wordLength = 0;
    bool isGameWon = false;

    public DisplayLetters dispLet;
    public CharacterMovement charMove;
    //public ClickZone zVal;
    public GameObject zone;
    public Material Blue;
  

    void Start()
    {
        charValueFrequencies.Add("A", 1);
        charValueFrequencies.Add("B", 1);
        charValueFrequencies.Add("C", 1);
        charValueFrequencies.Add("D", 1);
        charValueFrequencies.Add("E", 1);
        charValueFrequencies.Add("F", 1);
        charValueFrequencies.Add("G", 1);
        charValueFrequencies.Add("H", 1);
        charValueFrequencies.Add("I", 1);
        charValueFrequencies.Add("J", 1);
        charValueFrequencies.Add("K", 1);
        charValueFrequencies.Add("L", 1);
        charValueFrequencies.Add("M", 1);
        charValueFrequencies.Add("N", 1);
        charValueFrequencies.Add("O", 1);
        charValueFrequencies.Add("P", 1);
        charValueFrequencies.Add("Q", 1);
        charValueFrequencies.Add("R", 1);
        charValueFrequencies.Add("S", 1);
        charValueFrequencies.Add("T", 1);
        charValueFrequencies.Add("U", 1);
        charValueFrequencies.Add("V", 1);
        charValueFrequencies.Add("W", 1);
        charValueFrequencies.Add("X", 1);
        charValueFrequencies.Add("Y", 1);
        charValueFrequencies.Add("Z", 1);


        charWordFrequencies.Add("F", 1);
        charWordFrequencies.Add("A", 1);
        charWordFrequencies.Add("U", 1);
        charWordFrequencies.Add("L", 1);
        charWordFrequencies.Add("T", 1);

        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        panel4.gameObject.SetActive(false);
        panel5.gameObject.SetActive(false);

       

        foreach (KeyValuePair<string, int> item in charWordFrequencies)
        {
            wordLength += item.Value;
        }

        //zone = GameObject.FindGameObjectWithTag(ClickZone.zoneValue);
    }
  
    public void waittime()
    {
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        panel4.gameObject.SetActive(false);
        panel5.gameObject.SetActive(false);
    }
    private IEnumerator stoptime()
    {
        yield return new WaitForSeconds(10);
    }
 
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1.5f);

        if (charMove.healthCount < 1)
            SceneManager.LoadScene("StartGameScreen");
        else
            SceneManager.LoadScene("ArenaZone");
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            switch (other.gameObject.tag)
            {
                case "A":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "B":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "C":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "D":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "E":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "F":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "G":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "H":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "I":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "J":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "K":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "L":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "M":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "N":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "O":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "P":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);

                    break;
                case "Q":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "R":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "S":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "T":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "U":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "V":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "W":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "X":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "Y":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "Z":
                    charValueFrequencies[other.gameObject.tag]--;
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;

                default:
                    break;
            }

        
            

                if (charWordFrequencies.ContainsKey(other.gameObject.tag) && (charWordFrequencies[other.gameObject.tag] >= 0))

                {
                    charWordFrequencies[other.gameObject.tag]--;
                    countCorrectLetters += 1;
                }

                else
                {
                    if (!(other.gameObject.CompareTag("Obstacle")))
                    {


                    panel1.gameObject.SetActive(true);
                    Invoke("waittime", 0.5f);
           
                    Debug.Log("OOPS! You bumped into a wrong letter");
                        countIncorrectLetters += 1;

                        if (countIncorrectLetters == 3)
                        {
                            panel2.gameObject.SetActive(true);
                            Debug.Log("You collected 3 incorrected letters! - YOU NEED TO START OVER!!");
                        StartCoroutine(stoptime());
                        StartCoroutine(WaitForSceneLoad());
                       
                        }
                    }
                }

                if (countCorrectLetters == wordLength)
                {
                    for (int i = 0; i < charWordFrequencies.Count; i++)
                    {
                        if (charWordFrequencies[other.gameObject.tag] < 0)
                        {
                            isGameWon = false;
                            break;
                        }
                    }
                    if (isGameWon)
                    {
                        panel3.gameObject.SetActive(true);
                        Debug.Log("Congratulations! You've successfully spelt out the word - FAULT! SimonSays - YOU COMPLETED ZONE 2!!!");
                    StartCoroutine(stoptime());
                    StartCoroutine(WaitForSceneLoad());
                    
                    }
                    else
                    {
                        panel4.gameObject.SetActive(true);
                        Debug.Log("You've collected extra letters which are irrelevant to the word. Sorry, but SimonSays - YOU LOSE!!!");
                    StartCoroutine(stoptime());
                        StartCoroutine(WaitForSceneLoad());
                    
                    }

                }
            }
        catch (Exception)
        {
            panel5.gameObject.SetActive(true);
            Invoke("waittime", 0.5f);
          
            Debug.Log("You have bumped into the wrong letter!");
        }
    } 

}
