using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    public void newGameUI()
    {
        SceneManager.LoadScene("Unjumble");
    }

    public void continueUI()
    {
        SceneManager.LoadScene("ArenaZone");
    }

    public void quitUI()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
