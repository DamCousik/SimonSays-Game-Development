using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LetterPlacement : MonoBehaviour
{
    public int letterSpawn;
    public int xPos;
    private float zPos = 0;
    public GameObject[] letterDistribution;
    public List<GameObject> newLetterPlacements = new List<GameObject>();
    IEnumerable<GameObject> extraLetterList;
    public List<GameObject> letterDistList = new List<GameObject>();
    public List<GameObject> newExtraLetterList = new List<GameObject>();
    public List<GameObject> letterPlacementResult = new List<GameObject>();
    public Dictionary<string, int> wordAndIndexPairs = new Dictionary<string, int>();
    public Dictionary<int, string> oppositeWordIndex = new Dictionary<int, string>();
    public List<string> letterTags = new List<string>();
    public GameObject playerObj;
    public static bool arenaEntry;
    public static bool tgState;
    string tag;

    public GameObject[] toughLetterDistribution;
    public List<GameObject> toughLetterPlacements = new List<GameObject>();
    public int letterCount = 0;
    public int totalLetters;
    public int letterSpacing;
    public int correctLetterCount;
    public readonly string zoneWord = (SentenceJumble.originalWords[ClickZone.wordNum]).ToUpper();

    void Start()
    {
        arenaEntry = true;
        tgState = false;

        wordAndIndexPairs.Add("A", 0);
        wordAndIndexPairs.Add("B", 1);
        wordAndIndexPairs.Add("C", 2);
        wordAndIndexPairs.Add("D", 3);
        wordAndIndexPairs.Add("E", 4);
        wordAndIndexPairs.Add("F", 5);
        wordAndIndexPairs.Add("G", 6);
        wordAndIndexPairs.Add("H", 7);
        wordAndIndexPairs.Add("I", 8);
        wordAndIndexPairs.Add("J", 9);
        wordAndIndexPairs.Add("K", 10);
        wordAndIndexPairs.Add("L", 11);
        wordAndIndexPairs.Add("M", 12);
        wordAndIndexPairs.Add("N", 13);
        wordAndIndexPairs.Add("O", 14);
        wordAndIndexPairs.Add("P", 15);
        wordAndIndexPairs.Add("Q", 16);
        wordAndIndexPairs.Add("R", 17);
        wordAndIndexPairs.Add("S", 18);
        wordAndIndexPairs.Add("T", 19);
        wordAndIndexPairs.Add("U", 20);
        wordAndIndexPairs.Add("V", 21);
        wordAndIndexPairs.Add("W", 22);
        wordAndIndexPairs.Add("X", 23);
        wordAndIndexPairs.Add("Y", 24);
        wordAndIndexPairs.Add("Z", 25);

        oppositeWordIndex.Add(0, "A");
        oppositeWordIndex.Add(1, "B");
        oppositeWordIndex.Add(2, "C");
        oppositeWordIndex.Add(3, "D");
        oppositeWordIndex.Add(4, "E");
        oppositeWordIndex.Add(5, "F");
        oppositeWordIndex.Add(6, "G");
        oppositeWordIndex.Add(7, "H");
        oppositeWordIndex.Add(8, "I");
        oppositeWordIndex.Add(9, "J");
        oppositeWordIndex.Add(10, "K");
        oppositeWordIndex.Add(11, "L");
        oppositeWordIndex.Add(12, "M");
        oppositeWordIndex.Add(13, "N");
        oppositeWordIndex.Add(14, "O");
        oppositeWordIndex.Add(15, "P");
        oppositeWordIndex.Add(16, "Q");
        oppositeWordIndex.Add(17, "R");
        oppositeWordIndex.Add(18, "S");
        oppositeWordIndex.Add(19, "T");
        oppositeWordIndex.Add(20, "U");
        oppositeWordIndex.Add(21, "V");
        oppositeWordIndex.Add(22, "W");
        oppositeWordIndex.Add(23, "X");
        oppositeWordIndex.Add(24, "Y");
        oppositeWordIndex.Add(25, "Z");

        if (LevelDifficulty.difficulty.Equals("Easy"))
        {
            totalLetters = 60;
            letterSpacing = 5;
            correctLetterCount = 2;
        }
        else if (LevelDifficulty.difficulty.Equals("Medium"))
        {
            totalLetters = 90;
            letterSpacing = 4;
            correctLetterCount = 2;
        }
        else if (LevelDifficulty.difficulty.Equals("Hard"))
        {
            totalLetters = 120;
            letterSpacing = 3;
            correctLetterCount = 2;
        }
        else if (LevelDifficulty.difficulty.Equals("Extreme"))
        {
            totalLetters = 170;
            letterSpacing = 2;
            correctLetterCount = 3;
        }

        LetterPlacementForLevel(totalLetters, letterSpacing, correctLetterCount, zoneWord);
    }

    IEnumerator ObstacleDrop(GameObject letterSpawn, int spacing, string tag)
    {
        Vector3 position = Vector3.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            xPos = UnityEngine.Random.Range(1, -2);

            if (zPos < -345)
                zPos = 0;

            zPos -= spacing;
            position = new Vector3(xPos, (float)0.6, zPos);
            validPosition = true;

            Collider[] colliders = Physics.OverlapSphere(position, (spacing / 3));

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
            GameObject obj = Instantiate(letterSpawn, position, Quaternion.identity);
            obj.transform.tag = tag;
            obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.01);
            BoxCollider bc = (BoxCollider)obj.gameObject.AddComponent(typeof(BoxCollider));
            bc.center = Vector3.zero;
            bc.isTrigger = true;
            bc.size = new Vector3((float)1.1, (float)1.1, (float)1.1);
        }

        yield return new WaitForSeconds(0.005f);
    }

    void LetterPlacementForLevel(int totalLetters, int letterSpacing, int correctLetterCount, string zoneWord)
    {
        try
        {
            int difference = 0;

            for (int i = 0; i < correctLetterCount; i++)
            {
                for (int j = 0; j < zoneWord.Length; j++)
                {
                    Debug.Log("Letter 1 : " + zoneWord[j].ToString());
                    Debug.Log("Letter 2 : " + wordAndIndexPairs[zoneWord[j].ToString()]);
                    Debug.Log("Letter 3 : " + letterDistribution[wordAndIndexPairs[zoneWord[j].ToString()]]);
                    newLetterPlacements.Add(letterDistribution[wordAndIndexPairs[zoneWord[j].ToString()]]);
                    toughLetterPlacements.Add(toughLetterDistribution[wordAndIndexPairs[zoneWord[j].ToString()]]);
                }
            }

            foreach (GameObject gobj in newLetterPlacements)
            {
                Debug.Log("new Letter Placement list at the start = " + gobj);
            }

            letterDistList = letterDistribution.OfType<GameObject>().ToList();
            extraLetterList = letterDistList.Except(newLetterPlacements);
            newExtraLetterList = extraLetterList.OrderBy(x => Guid.NewGuid()).ToList();
            Debug.Log("Extralist count = " + newExtraLetterList.Count);

            while (newLetterPlacements.Count <= totalLetters)
            {
                newLetterPlacements.AddRange(newExtraLetterList);
            }

            difference = newLetterPlacements.Count - totalLetters;
            newLetterPlacements.RemoveRange(totalLetters, difference);

            letterPlacementResult = newLetterPlacements.OrderBy(x => Guid.NewGuid()).ToList();
            Debug.Log("Total Letter Count = " + totalLetters);

            for (int i = 0; i < letterPlacementResult.Count; i++)
            {
                tag = GetLetterTag(letterPlacementResult[i]);
                StartCoroutine(ObstacleDrop(letterPlacementResult[i], letterSpacing, tag));
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public string GetLetterTag(GameObject obj)
    {
        string lTag = "";
        for(int i = 0; i < letterDistribution.Length; i++)
        {
            if(obj == letterDistribution[i])
            {
                lTag = oppositeWordIndex[i];
            }
        }
        return lTag;
    }
}
