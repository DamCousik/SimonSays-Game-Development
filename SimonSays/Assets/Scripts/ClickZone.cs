using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickZone : MonoBehaviour
{
    public static string zoneValue;
    public static string zoneTag;
    public static int wordNum;
    public static int zoneNum;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Doing Ray test");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                zoneTag = hit.collider.gameObject.tag;
                //UnityEngine.Debug.Log("zoneTag");
                // Do not change the tag name, if you change, make sure to send zone number (n-1) to obtain letters to form nth word
                wordNum = zoneTag[1] - '0' - 1;
                //UnityEngine.Debug.Log(wordNum);

                Debug.Log("Hit Somthing" + hit.transform.tag);
                if (hit.collider.gameObject.name == "zone1")
                {
                    zoneValue = "z1";
                    SceneManager.LoadScene("Zone-A-Screen");
                }
                else if (hit.collider.gameObject.name == "zone2")
                {
                    zoneValue = "z2";
                    SceneManager.LoadScene("Zone-B-Screen");
                }
                else if (hit.collider.gameObject.name == "zone3")
                {
                    zoneValue = "z3";
                    SceneManager.LoadScene("Zone-C-Screen");
                }
                else if (hit.collider.gameObject.name == "zone4")
                {
                    zoneValue = "z4";
                    SceneManager.LoadScene("Zone-D-Screen");
                }
                else
                    Debug.Log("You've clicked a zone that doesn't belong to our world!!");
            }
        }
    }
}