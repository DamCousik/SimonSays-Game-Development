using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncorrectLetterChoices : MonoBehaviour
{
    GameObject player;
    GameObject lObj;
    public GameObject pTG;
    public static bool tgState = false;
    public static bool arenaEntry = false;
    int xPosition = 0;
    float position;
    CharacterMovement charMove;
    LetterCollection cm;
    LetterPlacement lp;
    int remaining = 0;
    public int newLetterCount = 0;

    IEnumerable<GameObject> toughLetterList;
    public List<GameObject> toughLetterPlt = new List<GameObject>();
    public List<GameObject> newToughLetterList = new List<GameObject>();
    public Dictionary<string, int> wIndexPairs = new Dictionary<string, int>();

    private void Start()
    {
        player = GameObject.Find("MaleFreeSimpleMovement1");
        charMove = player.GetComponent<CharacterMovement>();

        cm = player.GetComponent<LetterCollection>();

        lObj = GameObject.Find("Letters");
        lp = lObj.GetComponent<LetterPlacement>();

        position = (player.transform.position.z) - 20;

        wIndexPairs.Add("A", 0);
        wIndexPairs.Add("B", 1);
        wIndexPairs.Add("C", 2);
        wIndexPairs.Add("D", 3);
        wIndexPairs.Add("E", 4);
        wIndexPairs.Add("F", 5);
        wIndexPairs.Add("G", 6);
        wIndexPairs.Add("H", 7);
        wIndexPairs.Add("I", 8);
        wIndexPairs.Add("J", 9);
        wIndexPairs.Add("K", 10);
        wIndexPairs.Add("L", 11);
        wIndexPairs.Add("M", 12);
        wIndexPairs.Add("N", 13);
        wIndexPairs.Add("O", 14);
        wIndexPairs.Add("P", 15);
        wIndexPairs.Add("Q", 16);
        wIndexPairs.Add("R", 17);
        wIndexPairs.Add("S", 18);
        wIndexPairs.Add("T", 19);
        wIndexPairs.Add("U", 20);
        wIndexPairs.Add("V", 21);
        wIndexPairs.Add("W", 22);
        wIndexPairs.Add("X", 23);
        wIndexPairs.Add("Y", 24);
        wIndexPairs.Add("Z", 25);
    }

    public void ReturnToArena()
    {
        arenaEntry = true;
        tgState = false;
        if (charMove.healthCount < 1)
        {
            SceneManager.LoadScene("StartGameScreen");
            Debug.Log("Sorry you do not have enough lives!");
        }

        else
            SceneManager.LoadScene("ArenaZone");
    }

    public void LoseALife()
    { 
        cm.countIncorrectLetters = 0;
        cm.panelWrongLetter.SetActive(false);
        cm.stop = false;
        cm.panelBeforeArenaZone.SetActive(false);

        charMove.healthCount -= 1;
        if (charMove.healthCount == 2)
        {
            charMove.hb.size = 0.6f;
            charMove.hb.targetGraphic.color = Color.yellow;
        }
        else if (charMove.healthCount == 1)
        {
            charMove.hb.size = 0.2f;
            charMove.hb.targetGraphic.color = Color.red;
        }
        else if (charMove.healthCount < 1)
        {
            charMove.hb.gameObject.SetActive(false);
            charMove.chrctrIsDead = true;
            Debug.Log("You are all out of lives! Sorry, but SimonSays - YOU DIE!!");
            charMove.m_rigidBody.velocity = Vector3.zero;
            charMove.m_rigidBody.isKinematic = true;
            charMove.m_animator.gameObject.SetActive(false);
            charMove.healthCount = 0;
            cm.panelBeforeArenaZone.SetActive(false);
            cm.panelWrongLetter.SetActive(false);
            charMove.panelObstacle.gameObject.SetActive(false);
            charMove.gameOverPanel.SetActive(true);
        }
    }

    public void TougherGame()
    {
        try
        {
            Debug.Log("Player's Last Position = " + position);
            cm.countIncorrectLetters = 0;
            cm.stop = false;
            string zWord = (SentenceJumble.originalWords[ClickZone.wordNum]).ToUpper();

            if (LevelDifficulty.difficulty.Equals("Easy"))
            {
                lp.letterSpacing = 5;
                newLetterCount = 30;
            }

            else if (LevelDifficulty.difficulty.Equals("Medium"))
            {
                lp.letterSpacing = 4;
                newLetterCount = 20;
            }

            else if (LevelDifficulty.difficulty.Equals("Hard"))
            {
                lp.letterSpacing = 3;
                newLetterCount = 15;
            }

            else if (LevelDifficulty.difficulty.Equals("Extreme"))
            {
                lp.letterSpacing = 2;
                newLetterCount = 10;
            }

            toughLetterPlt = lp.toughLetterDistribution.OfType<GameObject>().ToList();
            toughLetterList = toughLetterPlt.Except(lp.toughLetterPlacements);
            newToughLetterList = toughLetterList.OrderBy(x => Guid.NewGuid()).ToList();

            remaining = newLetterCount - newToughLetterList.Count;

            if (remaining > 0)
            {
                for (int j = 0; j < remaining; j++)
                {
                    newToughLetterList.Add(newToughLetterList[j]);
                }
            }

            for (int i = 0; i < newLetterCount; i++)
            {
                StartCoroutine(ObstacleDropForTougherGame(newToughLetterList[i], lp.letterSpacing));
            }

            pTG.SetActive(false);
        }
        catch(Exception e)
        {
            Debug.Log("Error = " + e);
        }
    }

    IEnumerator ObstacleDropForTougherGame(GameObject letterSpawn, int spacing)
    {
        Vector3 letterPosition = Vector3.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            xPosition = UnityEngine.Random.Range(1, -2);

            if (position < -345)
                position = 0;

            position -= spacing;
            letterPosition = new Vector3(xPosition, (float)0.6, position);
            validPosition = true;

            Collider[] colliders = Physics.OverlapSphere(letterPosition, (spacing / 3));

            foreach (Collider col in colliders)
            {
                switch ((col.tag))
                {
                    case "Obstacle":
                    case "A":
                    case "B":
                    case "C":
                    case "D":
                    case "E":
                    case "F":
                    case "G":
                    case "H":
                    case "I":
                    case "J":
                    case "K":
                    case "L":
                    case "M":
                    case "N":
                    case "O":
                    case "P":
                    case "Q":
                    case "R":
                    case "S":
                    case "T":
                    case "U":
                    case "V":
                    case "W":
                    case "X":
                    case "Y":
                    case "Z":
                        validPosition = false;
                        break;

                    default:
                        break;
                }
            }
        }

        if (validPosition)
        {
            GameObject obj = Instantiate(letterSpawn, letterPosition, Quaternion.identity);
            obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.03);
        }

        yield return new WaitForSeconds(0.005f);

    }

    public void tougherGameInfo()
    {
        pTG.SetActive(true);
        tgState = true;
        arenaEntry = false;
        cm.panelBeforeArenaZone.SetActive(false);
        cm.panelWrongLetter.SetActive(false);
    }
}
