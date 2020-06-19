using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPlacement : MonoBehaviour
{
    GameObject letterSpawn;
    List<string> letterTags = new List<string>();
    //private int obstCount;
    private int xPos;
    private int zPos;
    public GameObject[] letterDistribution;
    public int letterCount;

    void Start()
    {
        Debug.Log("In start");
        //letterTags.Add("A");
        //letterTags.Add("B");
        //letterTags.Add("C");
        //letterTags.Add("D");
        //letterTags.Add("E");
        //letterTags.Add("F");
        //letterTags.Add("G");
        //letterTags.Add("H");
        //letterTags.Add("I");
        //letterTags.Add("J");
        //letterTags.Add("K");
        //letterTags.Add("L");
        //letterTags.Add("M");
        //letterTags.Add("N");
        //letterTags.Add("O");
        //letterTags.Add("P");
        //letterTags.Add("Q");
        //letterTags.Add("R");
        //letterTags.Add("S");
        //letterTags.Add("T");
        //letterTags.Add("U");
        //letterTags.Add("V");
        //letterTags.Add("W");
        //letterTags.Add("X");
        //letterTags.Add("Y");
        //letterTags.Add("Z");

        for (int i = 0; i < 26; i++)
        {
            letterCount = 0;
            letterSpawn = letterDistribution[i];
            while (letterCount < 3)
            {
                StartCoroutine(ObstacleDrop(letterSpawn));
                letterCount += 1;

            }

        }
    }

    IEnumerator ObstacleDrop(GameObject letterSpawn)
    {

        //Debug.Log(letterSpawn);
        //Debug.Log(letterCount);
        xPos = Random.Range(0, -2);
        zPos = Random.Range(10, -330);
        Debug.Log("xpos" + xPos);
        Debug.Log("xzpos" + zPos);
        GameObject obj = Instantiate(letterSpawn, new Vector3(xPos, (float)0.6, zPos), Quaternion.identity);
        obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.03);
        yield return new WaitForSeconds(0.003f);

    }
}
    
