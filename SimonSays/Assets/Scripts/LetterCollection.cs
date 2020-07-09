using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetterCollection : MonoBehaviour
{
    public static Dictionary<string, int> charWordFrequencies = new Dictionary<string, int>();
    public static Dictionary<string, bool> zoneState = new Dictionary<string, bool>();

    
    public List<string> collectedLetters = new List<string>();
    public int countIncorrectLetters = 0;
    public int countCorrectLetters = 0;
    public GameObject panelWrongLetter;
    public GameObject panelBeforeArenaZone;
    public GameObject tgButton;
    public GameObject arenaButton;
    public GameObject arenaButtonClone;
    public GameObject panelGameWon;
    public bool stop = false;
    public bool panelState = false;

    int wordLength = 0;
    public static bool isGameWon = false;
    public static string word;

    public string[] pFix = { "st", "nd", "rd", "th", "th"};

    public DisplayLetters dispLet;
    public CharacterMovement charMove;
    public string hintText;

    void Start()
    {
        word = SentenceJumble.originalWords[ClickZone.wordNum]; // Obtained from the arena
        UnityEngine.Debug.Log(word.ToUpper());

        dispLet.WordButtons(word);

        foreach (char c in word)
        {
            if (charWordFrequencies.ContainsKey(c.ToString().ToUpper()))
            {
                charWordFrequencies[c.ToString().ToUpper()]++;
            }
            else
            {
                charWordFrequencies[c.ToString().ToUpper()] = 1;
            }
        }

        wordLength = word.Length;

        Debug.Log("Word = " + word + " and Word Length at the beginning = " + wordLength);
        UnityEngine.Debug.Log("ClickZone.zoneTag : ---- : " + ClickZone.zoneTag);
        Debug.Log(" Zone Number = " + ClickZone.zoneTag[5]);
        Debug.Log(" Hint number  = " + ClickZone.zoneTag[5] + pFix[ClickZone.zoneTag[5] - '0' - 1]);

        hintText = "Collect " + ClickZone.zoneTag[5] + pFix[ClickZone.zoneTag[5] - '0' - 1] + " Word of Movie \n Click HERE to start";

        GameObject.Find("ZoneNumber").GetComponentInChildren<Text>().text = ClickZone.zoneTag;
        GameObject.Find("PanelHint").transform.GetChild(0).GetChild(0).GetComponent<Text>().text = hintText;
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

    private IEnumerator StopTime()
    {
        yield return new WaitForSeconds(10);
        panelGameWon.gameObject.SetActive(false);
    }

    public IEnumerator StopTimeForWrongLetter()
    {
        yield return new WaitForSeconds(10);
        panelWrongLetter.SetActive(false);
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
                Debug.Log("1) ---- You corrected the right letter! " + other.gameObject.tag);
                countCorrectLetters += 1;
            }

            else if (charWordFrequencies.ContainsKey(other.gameObject.tag) && (charWordFrequencies[other.gameObject.tag] <= 0))
            {
                countIncorrectLetters += 1;
                Debug.Log("2) ---- OOPS! You bumped into a wrong letter " + other.gameObject.tag);
            }

            else if (!(other.gameObject.CompareTag("Obstacle")) && !(other.gameObject.CompareTag("LethalObstacle")))
            {
                panelWrongLetter.gameObject.SetActive(true);
                StartCoroutine(StopTimeForWrongLetter());

                countIncorrectLetters += 1;
                Debug.Log("3) ---- OOPS! You bumped into a wrong letter " + other.gameObject.tag);
            }

            if (countIncorrectLetters == 3)
            {
                Debug.Log("4) ---- Entered condition for wrong letter! " + other.gameObject.tag);
                if (IncorrectLetterChoices.tgState)
                {
                    tgButton.SetActive(false);
                    arenaButton.SetActive(false);
                    arenaButtonClone.SetActive(true);
                }
                else if (IncorrectLetterChoices.arenaEntry)
                {
                    tgButton.SetActive(true);
                    arenaButton.SetActive(true);
                    arenaButtonClone.SetActive(false);
                }
                charMove.characterIsMoving = false;
                stop = true;
                panelBeforeArenaZone.SetActive(true);
                panelWrongLetter.SetActive(false);
                Debug.Log("You collected 3 incorrected letters! - YOU NEED TO START OVER!! " + other.gameObject.tag);
            }

            if ((countCorrectLetters == wordLength) && (countIncorrectLetters < 3))
            {
                Debug.Log("5) ---- Entered condition for right letter (win)! " + other.gameObject.tag);
                isGameWon = true;
                stop = true;
                charMove.chrctrIsDead = true;
                charMove.m_rigidBody.velocity = Vector3.zero;
                charMove.m_rigidBody.isKinematic = true;
                panelGameWon.SetActive(true);
                Debug.Log("Congratulations! You've successfully spelt out the word correctly! SimonSays - YOU COMPLETED THIS ZONE!!!");
                StartCoroutine(StopTime());
                StartCoroutine(WaitForSceneLoad());

                zoneState.Add(ClickZone.zoneTag, isGameWon);
            }
        }
        catch (Exception)
        {
            Debug.Log("You have bumped into the wrong letter!");
        }
    }
}
