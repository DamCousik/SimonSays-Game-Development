using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoImages : MonoBehaviour
{
    public GameObject unjumble;
    public Button Arrow1;
    public Button Arrow2;
    public Button Arrow3;
    public Button Arrow4;
    public Button Go;
    public Button GotIt1;
    public Button GotIt2;
    public Button GotIt3;
    public GameObject jumble;
    public GameObject arena;
    public GameObject arenaCompleted;
    public static int control=0;
    public void Start()
    {
        if(control==0)
        {
            unjumble.SetActive(true);
            Arrow1.gameObject.SetActive(true);
            GotIt1.gameObject.SetActive(true);
        }
        if(control==1)
        {
            arenaCompleted.SetActive(true);
            Arrow4.gameObject.SetActive(true);
            Go.gameObject.SetActive(true);
        }
        control = 1;
    }
    public void playNext()
    {
        unjumble.SetActive(false);
        jumble.SetActive(true);
        Arrow1.gameObject.SetActive(false);
        GotIt1.gameObject.SetActive(false);
        Arrow2.gameObject.SetActive(true);
        GotIt2.gameObject.SetActive(true);
    }
    public void playNext1()
    {      
        jumble.SetActive(false);
        arena.SetActive(true);
        Arrow2.gameObject.SetActive(false);
        GotIt2.gameObject.SetActive(false);
        Arrow3.gameObject.SetActive(true);
        GotIt3.gameObject.SetActive(true);
    }
    public void gotoDemo()
    {
        SceneManager.LoadScene("Demo");
    }
    public void chooseDifficulty()
    {
        SceneManager.LoadScene("Difficulty");
    }
}

