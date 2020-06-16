using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sentence
{
    public string sentence;

    [Header("leave empty if you want randomised")]
    public string desiredRandom;

    public string GetString()
    {
        if (!string.IsNullOrEmpty(desiredRandom))
        {
            return desiredRandom;
        }
        string result = sentence;

        while (result == sentence)
        {
            result = "";

            List<string> words = new List<string>(Regex.Matches(sentence, "\\w+").OfType<Match>().Select(m => m.Value).ToArray());
            //UnityEngine.Debug.Log(words[0]);
            //UnityEngine.Debug.Log(words[1]);
            //UnityEngine.Debug.Log(words.Count);
            while (words.Count > 0)
            {
                int indexWord = UnityEngine.Random.Range(0, words.Count - 1);
                result += words[indexWord];
                result += " ";

                words.RemoveAt(indexWord);
            }
        }
        //UnityEngine.Debug.Log("Scrambled sentence");
        //UnityEngine.Debug.Log(result);
        return result;
    }
}

public class SentenceJumble : MonoBehaviour
{
    public Sentence[] sentences;

    [Header("UI REFERENCE")]
    public WordObject prefab;
    public Transform container;
    public float space;
    public float lerpSpeed = 5;

    List<WordObject> wordObjects = new List<WordObject>();
    WordObject firstSelected;

    public int currentSentence;

    public static SentenceJumble main;

    private float timer = 30f;
    private Text timerSeconds;

    public void ChangeScene(string scene)
    {
        CheckSentence();
    }

    void Awake()
    {
        main = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ShowScramble(currentSentence);
        timerSeconds = GameObject.Find("Timer").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        RepositionObject();
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("0");
        if (timer <= 0)
        {
            CheckSentence();
        }
    }

    void RepositionObject()
    {
        if(wordObjects.Count == 0)
        {
            return;
        }

        float center = (wordObjects.Count - 1) / 2;
        for (int i =0; i<wordObjects.Count; i++)
        {
            wordObjects[i].rectTransform.anchoredPosition
                = Vector2.Lerp(wordObjects[i].rectTransform.anchoredPosition,
                new Vector2((i - center) * space, 0), lerpSpeed * Time.deltaTime);
            wordObjects[i].index = i;
        }
    }

    /// <summary>
    /// Show a random sentence on the screen
    /// </summary>
    public void ShowScramble()
    {
        ShowScramble(UnityEngine.Random.Range(0, sentences.Length - 1));
    }

    /// <summary>
    /// Show sentence from collection with desired index
    /// </summary>
    /// <param name="index"index of the element></param>
    public void ShowScramble(int index)
    {
        wordObjects.Clear();
        foreach(Transform child in container)
        {
            Destroy(child.gameObject);
        }

        //Sentences finished
        if (index > sentences.Length - 1)
        {
            UnityEngine.Debug.LogError("Index out of range, please enter range between 0-" + (sentences.Length - 1).ToString());
            return;
        }

        string words_s = sentences[index].GetString();
        //UnityEngine.Debug.Log("words_s");
        //UnityEngine.Debug.Log(words_s);
        string[] words_w = Regex.Matches(words_s, "\\w+").OfType<Match>().Select(m => m.Value).ToArray();
        //UnityEngine.Debug.Log("words_w");
        //UnityEngine.Debug.Log(words_w[0]);
        //UnityEngine.Debug.Log(words_w[1]);
        //UnityEngine.Debug.Log(words_w[2]);
        //UnityEngine.Debug.Log(words_w[3]);
        //UnityEngine.Debug.Log(words_w[4]);
        //UnityEngine.Debug.Log(words_w[5]);
        foreach (string w in words_w)
        {
            WordObject clone = Instantiate(prefab.gameObject).GetComponent<WordObject>();
            clone.transform.SetParent(container);

            wordObjects.Add(clone.Init(w));
        }

        currentSentence = index;
    }

    public void Swap (int indexA, int indexB) //Chack: May be not needed
    {
        WordObject tmpA = wordObjects[indexA];
        wordObjects[indexA] = wordObjects[indexB];
        wordObjects[indexB] = tmpA;

        wordObjects[indexA].transform.SetAsLastSibling();
        wordObjects[indexB].transform.SetAsLastSibling();

        //CheckSentence();
    }

    public void Select(WordObject wordObject)
    {
        if(firstSelected)
        {
            Swap(firstSelected.index, wordObject.index);

            //Unselect
            firstSelected.Select();
            wordObject.Select();
        } else
        {
            firstSelected = wordObject;
        }
    }

    public void UnSelect()
    {
        firstSelected = null;
    }

    public void CheckSentence()
    {
        StartCoroutine(CoCheckSentence()); //Check
    }

    IEnumerator CoCheckSentence() //Check
    {
        yield return new WaitForSeconds(0.5f);
        string sentence = "";
        foreach (WordObject wordObject in wordObjects)
        {
            sentence += " "; 
            sentence += wordObject.word;
            //UnityEngine.Debug.Log("sentence");
            //UnityEngine.Debug.Log(sentence);
        }

        //UnityEngine.Debug.Log("sentences[currentSentence].sentence");
        //UnityEngine.Debug.Log(sentences[currentSentence].sentence);
        if (sentence == sentences[currentSentence].sentence)
        {
            //currentSentence++;
            //ShowScramble(currentSentence);
            SceneManager.LoadScene("Arena");
        } else //I should add a screen to ask it to retry and start again?
        {
            SceneManager.LoadScene("WrongAns");
        }
    }
}