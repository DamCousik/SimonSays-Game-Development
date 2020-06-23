using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterCollection : MonoBehaviour
{ 
    public Dictionary<string, int> charWordFrequencies = new Dictionary<string, int>();
    public List<string> collectedLetters = new List<string>();
    public int countIncorrectLetters = 0;
    public int countCorrectLetters = 0;
    public GameObject panelWrongLetter;
    public GameObject panelBeforeArenaZone;
    public GameObject panelBeforeStartGame;
    public GameObject panelGameWon;
    public GameObject panelExtraLetters;

    int wordLength = 0;
    private bool isGameWon = false;
    string word;

    public DisplayLetters dispLet;
    public CharacterMovement charMove;
   
    void Start()
    {
        word = SentenceJumble.originalWords[ClickZone.wordNum]; // Obtained from the arena
        UnityEngine.Debug.Log(word.ToUpper());

        foreach (char c in word)        {
            if (charWordFrequencies.ContainsKey(c.ToString()))            {                charWordFrequencies[c.ToString().ToUpper()]++;            }            else            {                charWordFrequencies[c.ToString().ToUpper()] = 1;            }
        }        foreach (KeyValuePair<string, int> item in charWordFrequencies)        {            wordLength += item.Value;
        }
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);

        if (charMove.healthCount < 1)
        {
            SceneManager.LoadScene("StartGameScreen");
            Debug.Log("Sorry you do not have enough lives!");
        }
            
        else
            SceneManager.LoadScene("ArenaZone");
    }

    private IEnumerator StopTime()     {         yield return new WaitForSeconds(10);     } 
    private IEnumerator StopTimeForWrongLetter()
    {
        yield return new WaitForSeconds(2);
        panelWrongLetter.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        try
        {
            switch (other.gameObject.tag)
            {
                case "A":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "B":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "C":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "D":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "E":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "F":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "G":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "H":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "I":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "J":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "K":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "L":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "M":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "N":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "O":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "P":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);

                    break;
                case "Q":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "R":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "S":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "T":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "U":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "V":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "W":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "X":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "Y":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;
                case "Z":
                    collectedLetters.Add(other.gameObject.tag);
                    dispLet.DisplayCollectedLetters(other.gameObject.tag);
                    Destroy(other.gameObject);
                    break;

                default:
                    break;
            }

            if (charWordFrequencies.ContainsKey(other.gameObject.tag) && (charWordFrequencies[other.gameObject.tag] > 0))
            {
                charWordFrequencies[other.gameObject.tag]--;
                countCorrectLetters += 1;
            }

            else if (charWordFrequencies.ContainsKey(other.gameObject.tag) && (charWordFrequencies[other.gameObject.tag] <= 0))
            {
                countIncorrectLetters += 1;
            }

            else
            {
                if (!(other.gameObject.CompareTag("Obstacle")) && !(other.gameObject.CompareTag("LethalObstacle")))
                {
                    panelWrongLetter.gameObject.SetActive(true);
                    StartCoroutine(StopTimeForWrongLetter());

                    Debug.Log("OOPS! You bumped into a wrong letter");
                    countIncorrectLetters += 1;
                }
            }

            if (countIncorrectLetters == 3)
            {
                panelBeforeArenaZone.SetActive(true);
                charMove.chrctrIsDead = true;
                charMove.m_rigidBody.velocity = Vector3.zero;
                charMove.m_rigidBody.isKinematic = true;
                //charMove.m_animator.gameObject.SetActive(false);
                Debug.Log("You collected 3 incorrected letters! - YOU NEED TO START OVER!!");
                StartCoroutine(WaitForSceneLoad());
            }

            if ((countCorrectLetters == wordLength) && (countIncorrectLetters < 3))
            {
                isGameWon = true;
               
                panelGameWon.SetActive(true);
                charMove.chrctrIsDead = true;
                charMove.m_rigidBody.velocity = Vector3.zero;
                charMove.m_rigidBody.isKinematic = true;
                //charMove.m_animator.gameObject.SetActive(false);
                Debug.Log("Congratulations! You've successfully spelt out the word correctly! SimonSays - YOU COMPLETED THIS ZONE!!!");
                StartCoroutine(StopTime());
                StartCoroutine(WaitForSceneLoad());
                
                //else
                //{
                //    panelExtraLetters.SetActive(true);
                //    charMove.chrctrIsDead = true;
                //    charMove.m_rigidBody.velocity = Vector3.zero;
                //    charMove.m_rigidBody.isKinematic = true;
                //    charMove.m_animator.gameObject.SetActive(false);
                //    Debug.Log("You've collected extra letters which are irrelevant to the word. Sorry, but SimonSays - YOU LOSE!!!");
                //    StartCoroutine(StopTime());
                //    StartCoroutine(WaitForSceneLoad());
                //}

            }
        }
        catch(Exception)
        {
            Debug.Log("You have bumped into the wrong letter!");
        }
    }
}
