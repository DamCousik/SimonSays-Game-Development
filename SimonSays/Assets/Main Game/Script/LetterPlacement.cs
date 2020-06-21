using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPlacement : MonoBehaviour
{
    GameObject letterSpawn;
    private int xPos;
    private int zPos;
    public GameObject[] letterDistribution;

    public int letterCount;

    void Start()
    {
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
        xPos = Random.Range(0, -2);
        zPos = Random.Range(10, -330);
        Debug.Log("xpos" + xPos);
        Debug.Log("xzpos" + zPos);
        GameObject obj = Instantiate(letterSpawn, new Vector3(xPos, (float)0.6, zPos), Quaternion.identity);
        obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.03);
        yield return new WaitForSeconds(0.003f);

    }
}
