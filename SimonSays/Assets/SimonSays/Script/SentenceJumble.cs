using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;

    [Header("leave empty if you want randomised")]
    public string desiredRandom;

    public string GetString()
    {
        if (!string.IsNullOrEmpty(desiredRandom))
        {
            return desiredRandom;
        }
        string result = word;

        while (result == word)
        {
            result = "";
            List<char> characters = new List<char>(word.ToCharArray());
            while (characters.Count > 0)
            {
                int indexChar = UnityEngine.Random.Range(0, characters.Count - 1);
                result += characters[indexChar];

                characters.RemoveAt(indexChar);
            }
        }
        return result;
    }
}

public class SentenceJumble : MonoBehaviour
{
    public Word[] words;

    [Header("UI REFERENCE")]
    public WordObject prefab;
    public Transform container;
    public float space;
    public float lerpSpeed = 5;

    List<WordObject> charObjects = new List<WordObject>();
    WordObject firstSelected;

    public int currentWord;

    public static SentenceJumble main;

    void Awake()
    {
        main = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ShowScramble(currentWord);
    }

    // Update is called once per frame
    void Update()
    {
        RepositionObject();
    }

    void RepositionObject() //Check if needed or not
    {
        if(charObjects.Count == 0)
        {
            return;
        }

        float center = (charObjects.Count - 1) / 2;
        for (int i =0; i<charObjects.Count; i++)
        {
            charObjects[i].rectTransform.anchoredPosition
                = Vector2.Lerp(charObjects[i].rectTransform.anchoredPosition,
                new Vector2((i - center) * space, 0), lerpSpeed * Time.deltaTime);
            charObjects[i].index = i;
        }
    }

    /// <summary>
    /// Show a random word on the screen
    /// </summary>
    public void ShowScramble()
    {
        ShowScramble(UnityEngine.Random.Range(0, words.Length - 1));
    }

    /// <summary>
    /// Show word from collection with desired index
    /// </summary>
    /// <param name="index"index of the element></param>
    public void ShowScramble(int index)
    {
        charObjects.Clear();
        foreach(Transform child in container)
        {
            Destroy(child.gameObject);
        }

        //Words finished
        if (index > words.Length - 1)
        {
            UnityEngine.Debug.LogError("Index out of range, please enter range between 0-" + (words.Length - 1).ToString());
            return;
        }

        char[] chars = words[index].GetString().ToCharArray();
        foreach (char c in chars)
        {
            WordObject clone = Instantiate(prefab.gameObject).GetComponent<WordObject>();
            clone.transform.SetParent(container);

            charObjects.Add(clone.Init(c));
        }

        currentWord = index;
    }

    public void Swap (int indexA, int indexB) //Chaek: May be not needed
    {
        WordObject tmpA = charObjects[indexA];
        charObjects[indexA] = charObjects[indexB];
        charObjects[indexB] = tmpA;

        charObjects[indexA].transform.SetAsLastSibling();
        charObjects[indexB].transform.SetAsLastSibling();

        CheckWord();
    }

    public void Select(WordObject charObject)
    {
        if(firstSelected)
        {
            Swap(firstSelected.index, charObject.index);

            //Unselect
            firstSelected.Select();
            charObject.Select();
        } else
        {
            firstSelected = charObject;
        }
    }

    public void UnSelect()
    {
        firstSelected = null;
    }

    public void CheckWord()
    {
        StartCoroutine(CoCheckWord()); //Check
    }

    IEnumerator CoCheckWord() //Check
    {
        yield return new WaitForSeconds(0.5f);
        string word = "";
        foreach (WordObject charObject in charObjects)
        {
            word += charObject.character;
        }

        if (word == words[currentWord].word)
        {
            currentWord++;
            ShowScramble(currentWord);
        }
    }
}