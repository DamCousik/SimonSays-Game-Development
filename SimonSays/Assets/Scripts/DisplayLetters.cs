using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLetters : MonoBehaviour
{ 
    public GameObject inCorrectWordPanel;

    public GameObject correctLetters;
    public GameObject correctWordPanel;
    private GameObject[] btn;
    GameObject button;
    string newLetter;
    int index = 0;
    public float newLetterCount = 0;
    bool letterSetState = false;
    int i = 0;

    public void DisplayCollectedLetters(string letterValue)
    {
        bool state = false;
        foreach (KeyValuePair<string,int> c in LetterCollection.charWordFrequencies)
        {
            if((c.Key.Equals(letterValue)) && (c.Value > 0))
            {
                if(!string.IsNullOrEmpty(btn[newLetter.IndexOf(letterValue)].transform.GetChild(0).GetComponent<Text>().text))
                {
                    index = (newLetter.IndexOf(letterValue)) + 1;
                    btn[newLetter.IndexOf(letterValue, index)].transform.GetChild(0).GetComponent<Text>().text = " " + letterValue;
                }
                else
                    btn[newLetter.IndexOf(letterValue)].transform.GetChild(0).GetComponent<Text>().text = " " + letterValue;

                state = true;
            }
        }
        
        if (state == false)
        {
            if (i == 3)
                i = 0;

            LetterCollection.main.wrongLetters[i].transform.GetChild(0).GetComponent<Text>().text = " " + letterValue;
            i += 1;
        }
    }

    public void WordButtons(string word)
    {
        newLetter = word.ToUpper();

        if (newLetter.Length == 1)
            correctLetters.SetActive(true);
        else
        {
            for (int i = 1; i <= newLetter.Length - 1; i++)
            {
                correctLetters.SetActive(true);
                button = (GameObject)Instantiate(correctLetters);
                button.transform.SetParent(correctWordPanel.transform, false);
                button.transform.localScale = new Vector3(1.5f, 1.3f, 1.5f);
            }
        }

        btn = GameObject.FindGameObjectsWithTag("correctColLetter");
    }
}
