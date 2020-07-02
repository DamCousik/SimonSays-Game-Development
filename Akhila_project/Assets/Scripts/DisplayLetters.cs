using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLetters : MonoBehaviour
{
    public GameObject CollectedLetters;
    public GameObject Panel;

    public void DisplayCollectedLetters(string letterValue)
    {
        Debug.Log("Inside DisplayCollectedLettersa method");
        CollectedLetters.SetActive(true);
        Debug.Log("Looping over collected letters : " + letterValue);
        GameObject button = (GameObject)Instantiate(CollectedLetters);
        button.transform.SetParent(Panel.transform,false);
        button.transform.localScale = new Vector3(1.5f, 1.3f, 1.5f);
        button.transform.GetChild(0).GetComponent<Text>().text = letterValue;
        CollectedLetters.SetActive(false);
    }
}
