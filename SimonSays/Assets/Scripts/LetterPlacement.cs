using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LetterPlacement : MonoBehaviour
{
    int letterSpawn;
    private int xPos;
    private float zPos = 0;
    public GameObject[] letterDistribution;
    public List<GameObject> newLetterPlacements = new List<GameObject>();
    IEnumerable <GameObject> extraLetterList;
    public List<GameObject> letterDistList = new List<GameObject>();
    public List<GameObject> newExtraLetterList = new List<GameObject>();
    public List<GameObject> letterPlacementResult = new List<GameObject>();
    public Dictionary<string, int> wordAndIndexPairs = new Dictionary<string, int>();
    //string level = "Hard";

    public int letterCount = 0;
    int difference = 0;
    int totalLetters;
    int letterSpacing;
    int correctLetterCount;
    readonly string zoneWord = (SentenceJumble.originalWords[ClickZone.wordNum]).ToUpper();

    void Start()
    {
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

        if (LevelDifficulty.difficulty.Equals("Easy"))
        {
            totalLetters = 60;
            letterSpacing = 6;
            correctLetterCount = 2;
        }
        else if(LevelDifficulty.difficulty.Equals("Medium"))
        {
            totalLetters = 90;
            letterSpacing = 4;
            correctLetterCount = 2;
        }
        else if(LevelDifficulty.difficulty.Equals("Hard"))
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

    IEnumerator ObstacleDrop(GameObject letterSpawn, int spacing)
    {
        xPos = UnityEngine.Random.Range(1, -2);
        zPos -= spacing;
        
        GameObject obj = Instantiate(letterSpawn, new Vector3(xPos, (float)0.6, zPos), Quaternion.identity);
        
        obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.03);
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

            //remainingLetters = totalLetters - (zoneWord.Length * correctLetterCount);
            //Debug.Log("Remaining letters = " + remainingLetters);

            while(newLetterPlacements.Count <= totalLetters)
            {
               newLetterPlacements.AddRange(newExtraLetterList);
            }

            difference = newLetterPlacements.Count - totalLetters;
            newLetterPlacements.RemoveRange(totalLetters, difference);

            letterPlacementResult = newLetterPlacements.OrderBy(x => Guid.NewGuid()).ToList();

            foreach (GameObject gobj in newExtraLetterList)
            {
                Debug.Log("new Extra Placement list = " + gobj);
            }

            foreach (GameObject gobj in letterPlacementResult)
            {
                Debug.Log("new Letter Placement result at the end = " + gobj);
            }

            Debug.Log("Total letters: " + totalLetters);
            Debug.Log("New Letter Placement Count: " + newLetterPlacements.Count);

            for (int i = 0; i < letterPlacementResult.Count; i++)
            {
                StartCoroutine(ObstacleDrop(letterPlacementResult[i], letterSpacing));
            }
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        
    }
}
