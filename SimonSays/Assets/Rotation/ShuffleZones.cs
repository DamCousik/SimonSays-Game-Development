using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleZones : MonoBehaviour
{
    public GameObject[] zones;


    void Start()
    {
        StartCoroutine(ExecuteAfterTime(2));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Shuffle(zones);

    }

    void Shuffle (GameObject[] gameObjects) {
        for (int i = 0; i < gameObjects.Length; i++) {
 
            // Find a random index
            int destIndex = Random.Range (0, gameObjects.Length);
            GameObject source = gameObjects[i];
            GameObject dest = gameObjects[destIndex];
  /** This could be modified to keep checking to make sure you always swap something, but leaving it for now **/
            // If is not identical
            if (source != dest) {
 
                // Swap the positions
                Vector3 tmp = source.transform.position;
                source.transform.position = dest.transform.position;
                dest.transform.position = tmp;
                 
             /** I do not know what this was doing, try with it commented out! **/
                // Swap the array item
              //  gameObjects[i] = gameObjects[destIndex];
            }
        }
    }


    /*void Reset(GameObject[] gameObject)
    {
        
        BoxCollider boxCollider = (BoxCollider)gameObject.AddComponent(typeof(BoxCollider));
        boxCollider.center = Vector3.zero;

    }*/
    
}





 




 