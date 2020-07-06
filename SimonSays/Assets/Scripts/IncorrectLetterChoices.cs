using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncorrectLetterChoices : MonoBehaviour
{
    GameObject player;
    GameObject lObj;
    public GameObject pTG;
    public static bool tgState = false;
    public static bool arenaEntry = false;
    float position = 0;
    CharacterMovement charMove;
    LetterCollection cm;
    LetterPlacement lp;
    int remaining = 0;
    public int newLetterCount = 0;

    private void Start()
    {
        player = GameObject.Find("MaleFreeSimpleMovement1");
        charMove = player.GetComponent<CharacterMovement>();

        cm = player.GetComponent<LetterCollection>();

        lObj = GameObject.Find("Letters");
        lp = lObj.GetComponent<LetterPlacement>();

        position = (player.transform.position.z) - 20;
    }

    public void ReturnToArena()
    {
        arenaEntry = true;
        tgState = false;
        if (charMove.healthCount < 1)
        {
            SceneManager.LoadScene("StartGameScreen");
            Debug.Log("Sorry you do not have enough lives!");
        }

        else
            SceneManager.LoadScene("ArenaZone");
    }

    public void LoseALife()
    { 
        cm.countIncorrectLetters = 0;
        cm.panelWrongLetter.SetActive(false);
        cm.stop = false;
        cm.panelBeforeArenaZone.SetActive(false);

        charMove.healthCount -= 1;
        if (charMove.healthCount == 2)
        {
            charMove.hb.size = 0.6f;
            charMove.hb.targetGraphic.color = Color.yellow;
        }
        else if (charMove.healthCount == 1)
        {
            charMove.hb.size = 0.2f;
            charMove.hb.targetGraphic.color = Color.red;
        }
        else if (charMove.healthCount < 1)
        {
            charMove.hb.gameObject.SetActive(false);
            charMove.chrctrIsDead = true;
            Debug.Log("You are all out of lives! Sorry, but SimonSays - YOU DIE!!");
            charMove.m_rigidBody.velocity = Vector3.zero;
            charMove.m_rigidBody.isKinematic = true;
            charMove.m_animator.gameObject.SetActive(false);
            charMove.healthCount = 0;
            cm.panelBeforeArenaZone.SetActive(false);
            cm.panelWrongLetter.SetActive(false);
            charMove.panelObstacle.gameObject.SetActive(false);
            charMove.gameOverPanel.SetActive(true);
        }
    }

    public void TougherGame()
    {
        Debug.Log("Player's Last Position = " + position);
        cm.countIncorrectLetters = 0;
        cm.stop = false;
       
        if (LevelDifficulty.difficulty.Equals("Easy"))
        {
            lp.letterSpacing = 4;
            newLetterCount = 30;
        }

        else if (LevelDifficulty.difficulty.Equals("Medium"))
        {
            lp.letterSpacing = 3;
            newLetterCount = 20;
        }

        else if (LevelDifficulty.difficulty.Equals("Hard"))
        {
            lp.letterSpacing = 2;
            newLetterCount = 15;
        }

        else if (LevelDifficulty.difficulty.Equals("Extreme"))
        {
            lp.letterSpacing = 1;
            newLetterCount = 10;
        }

        remaining = newLetterCount - lp.newToughLetterList.Count;

        if(remaining > 0)
        {
            for (int j = 0; j < remaining; j++)
            {
                lp.newToughLetterList.Add(lp.newToughLetterList[j]);
            }
        }

        for (int i = 0; i < newLetterCount; i++)
        {
            if(position > -340)
                StartCoroutine(ObstacleDropForTougherGame(lp.newToughLetterList[i], lp.letterSpacing));
        }
        pTG.SetActive(false);
    }

    IEnumerator ObstacleDropForTougherGame(GameObject letterSpawn, int spacing)
    {
        lp.xPos = UnityEngine.Random.Range(1, -2);
        position -= spacing;

        GameObject obj = Instantiate(letterSpawn, new Vector3(lp.xPos, (float)0.6, position), Quaternion.identity);

        obj.transform.localScale = new Vector3((float)0.5, (float)0.5, (float)0.03);
        yield return new WaitForSeconds(0.005f);

    }

    public void tougherGameInfo()
    {
        pTG.SetActive(true);
        tgState = true;
        arenaEntry = false;
        cm.panelBeforeArenaZone.SetActive(false);
        cm.panelWrongLetter.SetActive(false);
    }
}
