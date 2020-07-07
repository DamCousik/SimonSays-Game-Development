using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelDifficulty : MonoBehaviour
{
    public static string difficulty;
    public static int level;

    public void difficultyUI()
    {
        difficulty = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Level");
    }

    public void levelUI()
    {
        level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene("Unjumble");
    }

    public void MenuUI()
    {
        SceneManager.LoadScene("StartGameScreen");
    }

    public void diffUI()
    {
        SceneManager.LoadScene("Difficulty");
    }
}