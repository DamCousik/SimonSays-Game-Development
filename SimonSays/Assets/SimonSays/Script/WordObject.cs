using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordObject : MonoBehaviour
{
    public char character;
    public Text text;
    public Image image;
    public RectTransform rectTransform;//Check
    public int index;

    [Header("Appearance")]
    public Color normalColor;
    public Color selectedColor;

    bool isSelected = false;

    public WordObject Init(char c)
    {
        character = c;
        text.text = c.ToString();
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
