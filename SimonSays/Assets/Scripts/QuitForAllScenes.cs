using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitForAllScenes : MonoBehaviour
{
    public GameObject panelExit;

    public void quitButton()
    {
        panelExit.SetActive(true);
    }

    public void yesOption()
    {
        SceneManager.LoadScene("StartGameScreen");
    }

    public void noOption()
    {
        panelExit.SetActive(false);
    }
}
