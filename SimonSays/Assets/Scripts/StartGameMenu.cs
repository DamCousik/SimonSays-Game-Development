using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

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

    public void instructionsUI() => SceneManager.LoadScene("InstructionScreen");

    public void ReturnUI()
    {
        SceneManager.LoadScene("StartGameScreen");
    }
    public void quitUI()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
        Application.Quit();
#elif (UNITY_WEBGL)
        Application.OpenURL("https://games.usc.edu/classes-mobilegames-526/");
#endif
        // SceneManager.LoadScene("StartGameScreen");
    }
}

