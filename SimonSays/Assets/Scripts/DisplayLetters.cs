using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLetters : MonoBehaviour
{
    public GameObject IncorrectLetters;
    public GameObject inCorrectWordPanel;

    public GameObject correctLetters;
    public GameObject correctWordPanel;
    private GameObject[] btn;
    GameObject button;
    bool state = false;
    string newLetter;

    public void DisplayCollectedLetters(string letterValue)
    {
        foreach(KeyValuePair<string,int> c in LetterCollection.charWordFrequencies)
        {
            if(c.Key.Equals(letterValue))
            {
                btn[newLetter.IndexOf(letterValue)].transform.GetChild(0).GetComponent<Text>().text = " " + letterValue;
                state = true;
            }
        }

        if (state == false)
        {
            IncorrectLetters.SetActive(true);
            button = (GameObject)Instantiate(IncorrectLetters);
            button.transform.SetParent(inCorrectWordPanel.transform, false);
            button.transform.localScale = new Vector3(1.5f, 1.3f, 1.5f);
            button.transform.GetChild(0).GetComponent<Text>().text = letterValue;
            IncorrectLetters.SetActive(false);
        }
    }

    public void wordButtons(string word)
    {
        newLetter = word.ToUpper();
        for(int i = 0; i < word.Length-1; i++)
        {
            correctLetters.SetActive(true);
            button = (GameObject)Instantiate(correctLetters);
            button.transform.SetParent(correctWordPanel.transform, false);
            button.transform.localScale = new Vector3(1.5f, 1.3f, 1.5f);
        }

        btn = GameObject.FindGameObjectsWithTag("correctColLetter");
    }
}
