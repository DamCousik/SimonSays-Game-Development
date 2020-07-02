using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordObject : MonoBehaviour
{
    public string word;
    public Text text;
    public Image image;
    public RectTransform rectTransform;
    public int index;

    [Header("Appearance")]
    public Color normalColor;
    public Color selectedColor;

    bool isSelected = false;

    public WordObject Init(string w)
    {
        word = w;
        text.text = w.ToString();
        gameObject.SetActive(true);
        return this;
    }

    public void Select()
    {
        isSelected = !isSelected;

        image.color = isSelected ? selectedColor : normalColor;
        if (isSelected)
        {
            SentenceJumble.main.Select(this);
        }
        else
        {
            SentenceJumble.main.UnSelect();
        }
    }
}
